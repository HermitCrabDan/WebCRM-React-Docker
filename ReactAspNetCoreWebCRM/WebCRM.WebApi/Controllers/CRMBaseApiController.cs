using Microsoft.AspNetCore.Mvc;
using WebCRM.Common;
using WebCRM.Data;
using WebCRM.Services;
using System.Net;
using WebCRM.Services.Security;

namespace webapi.Controllers
{
    [ApiController]
    public abstract class CRMBaseApiController<Dto, TEntity> : ControllerBase, ICRMBaseApiController<Dto, TEntity> 
        where Dto : class, IDto<TEntity>, new()
        where TEntity : class, IDataModel<TEntity>, new()
    {
        protected IDataService<Dto, TEntity> _dataService;
        protected ISecurityService _securityService;
        protected IAuthorizationService _authorizationService;
        protected ICustomerSecurityService _customerSecurityService;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="dataService">The data service for the entity</param>
        /// <param name="securityService">The security service</param>
        /// <param name="authorizationService">The authorization service</param>
        /// <param name="customerSecurityService">The customer secuirty service</param>
        public CRMBaseApiController(
            IDataService<Dto, TEntity> dataService,
            ISecurityService securityService,
            IAuthorizationService authorizationService,
            ICustomerSecurityService customerSecurityService)
        {
            this._dataService = dataService;
            this._securityService = securityService;
            this._authorizationService = authorizationService;
            this._customerSecurityService = customerSecurityService;
        }

        /// <summary>
        /// Creates a entity for the dto
        /// </summary>
        /// <param name="viewModel">The dto object</param>
        /// <param name="cancellationToken">Th cancellation token</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Create(Dto viewModel, CancellationToken cancellationToken = default)
        {
            if (viewModel == null)
            {
                return NoContent();
            }

            var loggedInUser = await this._authorizationService.GetLoggedInUserAsync();
            if (loggedInUser == null)
            {
                return Unauthorized();
            }

            if (!await this._securityService.CanCreateAsync<TEntity>(loggedInUser.UserId))
            {
                return Forbid();
            }

            var dataServiceResponse = await this._dataService.CreateAsync(viewModel, cancellationToken);
            if (!dataServiceResponse.Success)
            {
                return NotFound(new ErrorResponseDto(HttpStatusCode.NotFound, dataServiceResponse.Message));
            }

            return Ok(dataServiceResponse.Value);
        }

        /// <summary>
        /// Gets the details for the entity
        /// </summary>
        /// <param name="id">the id of the entity</param>
        /// <param name="cancellationToken">the cancellation token</param>
        /// <returns>ActionResult</returns>
        [HttpGet]
        public virtual async Task<IActionResult> Details(int id, CancellationToken cancellationToken = default)
        {
            if (id == default)
            {
                return NoContent();
            }

            var loggedInUser = await this._authorizationService.GetLoggedInUserAsync();
            if (loggedInUser == null)
            {
                return Unauthorized();
            }

            if (!await this._securityService.CanViewAllAsync<TEntity>(loggedInUser.UserId))
            {
                //If there is a role that allows the user to view all, check the entity instance
                if (!await this._customerSecurityService.CanCustomerViewEntityAsync<TEntity>(loggedInUser.UserId, id))
                {
                    return Forbid();
                }
            }

            var dataServiceResponse = await this._dataService.GetByIdAsync(id, cancellationToken);
            if (!dataServiceResponse.Success)
            {
                return NotFound(new ErrorResponseDto(HttpStatusCode.NotFound, dataServiceResponse.Message));
            }

            return Ok(dataServiceResponse.Value);
        }

        /// <summary>
        /// Updates the entity with the dto values
        /// </summary>
        /// <param name="viewModel">The dto with the updated values</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Update(Dto viewModel, CancellationToken cancellationToken = default)
        {
            if (viewModel == null)
            {
                return NoContent();
            }

            var loggedInUser = await this._authorizationService.GetLoggedInUserAsync();
            if (loggedInUser == null)
            {
                return Unauthorized();
            }

            if (!await this._securityService.CanUpdateAsync<TEntity>(loggedInUser.UserId))
            {
                return Forbid();
            }

            var dataServiceResponse = await this._dataService.UpdateAsync(viewModel, cancellationToken);
            if (!dataServiceResponse.Success)
            {
                return NotFound(new ErrorResponseDto(HttpStatusCode.NotFound, dataServiceResponse.Message));
            }

            return Ok(dataServiceResponse.Value);
        }

        /// <summary>
        /// Deletes the entity matching the dto
        /// </summary>
        /// <param name="viewModel">The dto</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Delete(Dto viewModel, CancellationToken cancellationToken = default)
        {
            if (viewModel == null)
            {
                return NoContent();
            }

            var loggedInUser = await this._authorizationService.GetLoggedInUserAsync();
            if (loggedInUser == null)
            {
                return Unauthorized();
            }

            if (!await this._securityService.CanDeleteAsync<TEntity>(loggedInUser.UserId))
            {
                return Forbid();
            }

            var dataServiceResponse = await this._dataService.DeleteAsync(viewModel, cancellationToken);
            if (!dataServiceResponse.Success)
            {
                return NotFound(new ErrorResponseDto(HttpStatusCode.NotFound, dataServiceResponse.Message));
            }

            return Ok(dataServiceResponse.Value);
        }
    }
}
