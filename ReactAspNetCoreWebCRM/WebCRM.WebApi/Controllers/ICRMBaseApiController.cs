using Microsoft.AspNetCore.Mvc;
using WebCRM.Data;
using WebCRM.Services;

namespace webapi.Controllers
{
    public interface ICRMBaseApiController<Dto, TEntity>
        where Dto : class, IDto<TEntity>, new()
        where TEntity : class, IDataModel<TEntity>, new()
    {
        /// <summary>
        /// Creates a entity for the dto
        /// </summary>
        /// <param name="viewModel">The dto object</param>
        /// <param name="cancellationToken">Th cancellation token</param>
        /// <returns>ActionResult</returns>
        Task<IActionResult> Create(Dto viewModel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the entity matching the dto
        /// </summary>
        /// <param name="viewModel">The dto</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>ActionResult</returns>
        Task<IActionResult> Delete(Dto viewModel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the details for the entity
        /// </summary>
        /// <param name="id">the id of the entity</param>
        /// <param name="cancellationToken">the cancellation token</param>
        /// <returns>ActionResult</returns>
        Task<IActionResult> Details(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the entity with the dto values
        /// </summary>
        /// <param name="viewModel">The dto with the updated values</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>ActionResult</returns>
        Task<IActionResult> Update(Dto viewModel, CancellationToken cancellationToken = default);
    }
}