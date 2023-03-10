using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Common;

namespace WebCRM.Services
{
    /// <summary>
    /// The data service for view models
    /// </summary>
    /// <typeparam name="ViewModel">The view model</typeparam>
    /// <typeparam name="DataModel">The data model</typeparam>
    public interface IDataService<ViewModel, DataModel> where ViewModel : class, IViewModel<DataModel>, new()
    {
        /// <summary>
        /// Returns the view model for the selected model id
        /// </summary>
        /// <param name="id">The id of the data model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>IDataServiceResponseModel of the object</returns>
        Task<IResponseModel<ViewModel>> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Saves the base model to the database and returns the view model of the created model
        /// </summary>
        /// <param name="model">The view model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>IDataServiceResponseModel of the object</returns>
        Task<IResponseModel<ViewModel>> CreateAsync(ViewModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the related base model in the database
        /// </summary>
        /// <param name="model">The view model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>IDataServiceResponseModel of the object</returns>
        Task<IResponseModel<ViewModel>> UpdateAsync(ViewModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the related object from the database
        /// </summary>
        /// <param name="model">The view model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>IDataServiceResponseModel of the object</returns>
        Task<IResponseModel<ViewModel>> DeleteAsync(ViewModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a paginated list view models
        /// </summary>
        /// <param name="parameters">The pagination parameters</param>
        /// <param name="expression">The filter expression</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>IPagedList of view models</returns>
        Task<IPagedList<ViewModel>> RetrieveListAsync(
            QueryStringParameters parameters, 
            Expression<Func<DataModel, bool>>? expression = null, 
            CancellationToken cancellationToken = default);
    }
}
