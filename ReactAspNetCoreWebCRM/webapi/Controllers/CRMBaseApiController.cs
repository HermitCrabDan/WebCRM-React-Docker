using Microsoft.AspNetCore.Mvc;
using WebCRM.Common;
using WebCRM.Data;
using WebCRM.Services;
using System.Net;

namespace webapi.Controllers
{
    [ApiController]
    public class CRMBaseApiController<ViewModel, DataModel>: ControllerBase 
        where ViewModel : class, IDto<DataModel>, new () 
        where DataModel : class, IDataModel<DataModel>, new()
    {
        protected IDataService<ViewModel, DataModel> _dataService;

        public CRMBaseApiController(IDataService<ViewModel, DataModel> dataService)
        {
            this._dataService = dataService;
        }

        [HttpGet]
        public virtual IActionResult New()
        {
            return Ok(new ViewModel());
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(ViewModel viewModel, CancellationToken cancellationToken = default)
        {
            if (viewModel == null)
            {
                return NoContent();
            }

            var dataServiceResponse = await this._dataService.CreateAsync(viewModel, cancellationToken);
            if (!dataServiceResponse.Success)
            {
                return NotFound(new ErrorResponseDto(HttpStatusCode.NotFound, dataServiceResponse.Message));
            }

            return Ok(dataServiceResponse.Value);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Details(int id, CancellationToken cancellationToken = default)
        {
            var dataServiceResponse = await this._dataService.GetByIdAsync(id, cancellationToken);
            if (!dataServiceResponse.Success)
            {
                return NotFound(new ErrorResponseDto(HttpStatusCode.NotFound, dataServiceResponse.Message));
            }

            return Ok(dataServiceResponse.Value);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Update(ViewModel viewModel, CancellationToken cancellationToken = default)
        {
            if (viewModel == null)
            {
                return NoContent();
            }

            var dataServiceResponse = await this._dataService.UpdateAsync(viewModel, cancellationToken);
            if (!dataServiceResponse.Success)
            {
                return NotFound(new ErrorResponseDto(HttpStatusCode.NotFound, dataServiceResponse.Message));
            }

            return Ok(dataServiceResponse.Value);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Delete(ViewModel viewModel,  CancellationToken cancellationToken = default)
        {
            var dataServiceResponse = await this._dataService.DeleteAsync(viewModel, cancellationToken);
            if (!dataServiceResponse.Success)
            {
                return NotFound(new ErrorResponseDto(HttpStatusCode.NotFound, dataServiceResponse.Message));
            }

            return Ok(dataServiceResponse.Value);
        }
    }
}
