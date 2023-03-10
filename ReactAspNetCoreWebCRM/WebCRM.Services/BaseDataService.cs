using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Common;
using WebCRM.Data;
using WebCRM.Data.Repositories;

namespace WebCRM.Services
{
    public abstract class BaseDataService<Dto, TEntity> : IDataService<Dto, TEntity> 
        where TEntity : class, IDataModel<TEntity>, new()
        where Dto : class, IDto<TEntity>, new()
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IEnumerable<string> _singleIncludeProperties;
        protected readonly IEnumerable<string> _listIncludeProperties;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">The base data repository</param>
        public BaseDataService(IRepository<TEntity> repository) 
        {
            this._repository = repository;
            this._singleIncludeProperties = new List<string>();
            this._listIncludeProperties = new List<string>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">The base data repository</param>
        /// <param name="singleIncludeProperties">The child objects to include when a single object is returned</param>
        /// <param name="listIncludeProperties">The child objects to return with each item in the list</param>
        public BaseDataService(IRepository<TEntity> repository,
            IEnumerable<string> singleIncludeProperties,
            IEnumerable<string> listIncludeProperties)
        {
            this._repository = repository;
            this._singleIncludeProperties = singleIncludeProperties;
            this._listIncludeProperties = listIncludeProperties;
        }

        /// <summary>
        /// Returns the view model for the selected model id
        /// </summary>
        /// <param name="id">The id of the data model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>IDataServiceResponseModel of the object</returns>
        public virtual async Task<IResponseModel<Dto>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var repositoryResponse = await this._repository.GetByIdAsync(id, _singleIncludeProperties, cancellationToken);
            var viewModel = new Dto();

            if (repositoryResponse.Value != null && repositoryResponse.Success)
            {
                viewModel.SetModel(repositoryResponse.Value);
            }

            return repositoryResponse.ToResponseModel(viewModel);
        }

        /// <summary>
        /// Saves the base model to the database and returns the view model of the created model
        /// </summary>
        /// <param name="model">The view model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>IDataServiceResponseModel of the object</returns>
        public virtual async Task<IResponseModel<Dto>> CreateAsync(Dto model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                return new ResponseModel<Dto>(false, false, CRMConstants.NullDataSent, new Dto());
            }

            var modelToCreate = model.ToBaseModel();
            var repositoryResponse = await this._repository.CreateAsync(modelToCreate, cancellationToken);
            if (repositoryResponse.Value != null && repositoryResponse.Success)
            {
                model.SetModel(repositoryResponse.Value);
            }

            return repositoryResponse.ToResponseModel(model);
        }

        /// <summary>
        /// Updates the related base model in the database
        /// </summary>
        /// <param name="model">The view model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>IDataServiceResponseModel of the object</returns>
        public virtual async Task<IResponseModel<Dto>> UpdateAsync(Dto model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                return new ResponseModel<Dto>(false, false, CRMConstants.NullDataSent, new Dto());
            }

            var modelToUpdate = model.ToBaseModel();
            var repositoryResponse = await this._repository.UpdateAsync(modelToUpdate, cancellationToken);
            if (repositoryResponse.Value != null && repositoryResponse.Success)
            {
                model.SetModel(repositoryResponse.Value);
            }

            return repositoryResponse.ToResponseModel(model);
        }

        /// <summary>
        /// Deletes the related object from the database
        /// </summary>
        /// <param name="model">The view model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>IDataServiceResponseModel of the object</returns>
        public virtual async Task<IResponseModel<Dto>> DeleteAsync(Dto model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                return new ResponseModel<Dto>(false, false, CRMConstants.NullDataSent, new Dto());
            }

            var repositoryResponse = await this._repository.DeleteAsync(model.Id, cancellationToken);
            if (repositoryResponse.Value != null && repositoryResponse.Success)
            {
                model.SetModel(repositoryResponse.Value);
            }

            return repositoryResponse.ToResponseModel(model);
        }

        /// <summary>
        /// Returns a paginated list view models
        /// </summary>
        /// <param name="parameters">The pagination parameters</param>
        /// <param name="expression">The filter expression</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>IPagedList of view models</returns>
        public virtual async Task<IPagedList<Dto>> RetrieveListAsync(
            QueryStringParameters parameters, 
            Expression<Func<TEntity, bool>>? expression = null, 
            CancellationToken cancellationToken = default)
        {
            var data = _repository.RepositoryTable;
            if (this._listIncludeProperties.Any())
            {
                foreach( var listProperty in  this._listIncludeProperties)
                {
                    data = data.Include(listProperty);
                }
            }

            if (expression != null)
            {
                data = data.Where(expression);
            }

            return await data.ToPagedViewModelList<Dto, TEntity>(parameters.PageNumber, parameters.PageSize);
        }
    }
}
