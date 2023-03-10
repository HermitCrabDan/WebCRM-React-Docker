using WebCRM.Common;

namespace WebCRM.Data
{
    public interface IRepository<T> where T : class, IDataModel<T>, new()
    {
        /// <summary>
        /// The queryable table
        /// </summary>
        IQueryable<T> RepositoryTable { get; }

        /// <summary>
        /// Adds the model to the database
        /// </summary>
        /// <param name="model">The model to add</param>
        /// <param name="cancellationToken">the cancellation token</param>
        /// <returns>IRepositoryResponseModel of the created model</returns>
        Task<IResponseModel<T>> CreateAsync(T model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets model by the id
        /// </summary>
        /// <param name="id">the id of the model</param>
        /// <param name="cancellationToken">the cancellation token</param>
        /// <returns>IRepositoryResponseModel of the model</returns>
        Task<IResponseModel<T>> GetByIdAsync(
            int id,
            IEnumerable<string> includeProperties,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the matching entity in the database
        /// </summary>
        /// <param name="model">The model with the updated values</param>
        /// <param name="cancellationToken">the cancellation token</param>
        /// <returns>IRepositoryResponseModel of the updated model</returns>
        Task<IResponseModel<T>> UpdateAsync(T model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the entity from the database with the matching Id
        /// </summary>
        /// <param name="id">The id of the entity to delete</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>IRepositoryResponseModel with the model that was deleted</returns>
        Task<IResponseModel<T>> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
