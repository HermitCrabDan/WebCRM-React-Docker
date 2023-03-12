using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using WebCRM.Common;

namespace WebCRM.Data
{
    /// <summary>
    /// The base repository implementation
    /// </summary>
    /// <typeparam name="DataModel">The database entity</typeparam>
    public abstract class BaseRepository<DataModel> : IRepository<DataModel>
        where DataModel : class, IDataModel<DataModel>, new()
    {
        protected readonly ICRMDataContext _dataContext;
        protected readonly ILogger _logger;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="dataContext">The data context</param>
        /// <param name="logger">The logger</param>
        public BaseRepository(ICRMDataContext dataContext, ILogger logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        /// <summary>
        /// The queryable table
        /// </summary>
        public virtual IQueryable<DataModel> RepositoryTable
        {
            get
            {
                return _dataContext.Set<DataModel>().AsQueryable();
            }
        }

        /// <summary>
        /// Adds the model to the database
        /// </summary>
        /// <param name="model">The model to add</param>
        /// <param name="cancellationToken">the cancellation token</param>
        /// <returns>A boolean representing success, and the created model</returns>
        public virtual async Task<IResponseModel<DataModel>> CreateAsync(DataModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                return new ResponseModel<DataModel>(false, false, CRMConstants.NullDataSent, model);
            }

            if (_logger != null)
            {
                _logger.Log(logLevel: LogLevel.Information, $"{nameof(DataModel)} Repository CreateAsync called model: {model.ToString()}");
            }

            try
            {
                model.CreatedDate = DateTime.UtcNow;
                await _dataContext.Set<DataModel>().AddAsync(model, cancellationToken);
                var changesSaved = await _dataContext.SaveChangesAsync(cancellationToken);
                bool success = changesSaved > 0;
                var message = success ? CRMConstants.SuccessfullySavedChanges : CRMConstants.FailedToSaveChanges;
                return new ResponseModel<DataModel>(success, true, message, model);
            }
            catch (Exception ex)
            {
                if (_logger != null)
                {
                    var message = $"{nameof(DataModel)} Repository CreateAsync error: " + ex.Message;
                    _logger.LogError(ex, message);
                }

                return new ResponseModel<DataModel>(false, true, CRMConstants.DatabaseError, model);
            }
        }

        /// <summary>
        /// Gets model by the id
        /// </summary>
        /// <param name="id">the id of the model</param>
        /// <param name="includeProperties">the child objects to return</param>
        /// <param name="cancellationToken">the cancellation token</param>
        /// <returns>A boolean representing success, and the model</returns>
        public virtual async Task<IResponseModel<DataModel>> GetByIdAsync(
            int id,
            IEnumerable<string> includeProperties,
            CancellationToken cancellationToken = default)
        {
            if (_logger != null)
            {
                _logger.Log(logLevel: LogLevel.Information, $"{nameof(DataModel)} Repository GetByIdAsync called id: {id}");
            }

            try
            {
                var data = RepositoryTable;
                if (includeProperties != null && includeProperties.Any())
                {
                    foreach (var property in includeProperties)
                    {
                        data = data.Include(property);
                    }
                }

                var model = await data.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                var modelExists = model != null;
                var message = modelExists ? string.Empty : CRMConstants.NoMatchingDataFound;
                return new ResponseModel<DataModel>(modelExists, false, message, model);
            }
            catch (Exception ex)
            {
                if (_logger != null)
                {
                    _logger.LogError(ex, $"{nameof(DataModel)} Repository GetByIdAsync error: " + ex.Message);
                }

                return new ResponseModel<DataModel>(message: CRMConstants.DatabaseError);
            }
        }

        /// <summary>
        /// Updates the matching entity in the database
        /// </summary>
        /// <param name="model">The model with the updated values</param>
        /// <param name="cancellationToken">the cancellation token</param>
        /// <returns>A boolean representing success, and the updated model</returns>
        public virtual async Task<IResponseModel<DataModel>> UpdateAsync(DataModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                return new ResponseModel<DataModel>(false, false, CRMConstants.NullDataSent, model);
            }

            if (_logger != null)
            {
                _logger.Log(logLevel: LogLevel.Information, $"{nameof(DataModel)} Repository UpdateAsync called model: {model.ToString()}");
            }

            try
            {
                var modelToUpdate = await _dataContext.Set<DataModel>().FirstOrDefaultAsync(x => x.Id == model.Id, cancellationToken);
                if (modelToUpdate == null)
                {
                    return new ResponseModel<DataModel>(false, false, CRMConstants.NoMatchingDataFound, model);
                }

                var changesMade = modelToUpdate.SecureUpdate(model);
                if (!changesMade)
                {
                    return new ResponseModel<DataModel>(true, false, CRMConstants.NoChangesToSave, model);
                }

                modelToUpdate.ModifiedDate = DateTime.UtcNow;
                _dataContext.Set<DataModel>().Update(modelToUpdate);
                var changesSaved = await _dataContext.SaveChangesAsync(cancellationToken);
                bool success = changesSaved > 0;
                var message = success ? CRMConstants.SuccessfullySavedChanges : CRMConstants.FailedToSaveChanges;
                return new ResponseModel<DataModel>(success, changesMade, message, model);
            }
            catch (Exception ex)
            {
                if (_logger != null)
                {
                    _logger.LogError(ex, $"{nameof(DataModel)} Repository UpdateAsync error: " + ex.Message);
                }

                return new ResponseModel<DataModel>(false, false, CRMConstants.DatabaseError, model);
            }
        }

        /// <summary>
        /// Deletes the entity from the database with the matching Id
        /// </summary>
        /// <param name="id">The id of the entity to delete</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A boolean value representing the success of the deletion</returns>
        public virtual async Task<IResponseModel<DataModel>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            if (_logger != null)
            {
                _logger.Log(logLevel: LogLevel.Information, $"{nameof(DataModel)} Repository DeleteAsync called id: {id}");
            }

            try
            {
                var modelToDelete = await _dataContext.Set<DataModel>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                if (modelToDelete == null)
                {
                    return new ResponseModel<DataModel>(false, false, CRMConstants.NoMatchingDataFound, modelToDelete);
                }

                int changesSaved = 0;
                if (modelToDelete is ISoftDeleted)
                {
                    var softDeleteProperty = typeof(DataModel).GetProperties()
                        .FirstOrDefault(x => x.Name == nameof(SoftDeletedModel.DeletedDate));
                    if (softDeleteProperty != null)
                    {
                        softDeleteProperty.SetValue(modelToDelete, DateTime.UtcNow);
                        _dataContext.Set<DataModel>().Update(modelToDelete);
                        changesSaved = await _dataContext.SaveChangesAsync(cancellationToken);
                    }
                }
                else
                {
                    _dataContext.Set<DataModel>().Remove(modelToDelete);
                    changesSaved = await _dataContext.SaveChangesAsync(cancellationToken);
                }

                var success = changesSaved > 0;
                var message = success ? CRMConstants.SuccessfullySavedChanges : CRMConstants.FailedToSaveChanges;
                return new ResponseModel<DataModel>(success, true, message, modelToDelete);
            }
            catch (Exception ex)
            {
                if (_logger != null)
                {
                    _logger.LogError(ex, $"{nameof(DataModel)} Repository DeleteAsync error: " + ex.Message);
                }

                return new ResponseModel<DataModel>(message: CRMConstants.DatabaseError);
            }
        }
    }
}
