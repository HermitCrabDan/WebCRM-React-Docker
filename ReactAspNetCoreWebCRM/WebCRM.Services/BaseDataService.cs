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
    public class BaseDataService<ViewModel, DataModel> : IDataService<ViewModel, DataModel> 
        where DataModel : class, IDataModel<DataModel>, new()
        where ViewModel : class, IViewModel<DataModel>, new()
    {
        protected readonly IRepository<DataModel> _repository;
        protected readonly IEnumerable<string> _singleIncludeProperties;
        protected readonly IEnumerable<string> _listIncludeProperties;

        public BaseDataService(IRepository<DataModel> repository) 
        {
            this._repository = repository;
            this._singleIncludeProperties = new List<string>();
            this._listIncludeProperties = new List<string>();
        }

        public BaseDataService(IRepository<DataModel> repository,
            IEnumerable<string> singleIncludeProperties,
            IEnumerable<string> listIncludeProperties)
        {
            this._repository = repository;
            this._singleIncludeProperties = singleIncludeProperties;
            this._listIncludeProperties = listIncludeProperties;
        }

        public virtual async Task<IResponseModel<ViewModel>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var repositoryResponse = await this._repository.GetByIdAsync(id, _singleIncludeProperties, cancellationToken);
            var viewModel = new ViewModel();

            if (repositoryResponse.Value != null && repositoryResponse.Success)
            {
                viewModel.SetModel(repositoryResponse.Value);
            }

            return repositoryResponse.ToResponseModel(viewModel);
        }

        public virtual async Task<IResponseModel<ViewModel>> CreateAsync(ViewModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                return new ResponseModel<ViewModel>(false, false, CRMConstants.NullDataSent, new ViewModel());
            }

            var modelToCreate = model.ToBaseModel();
            var repositoryResponse = await this._repository.CreateAsync(modelToCreate, cancellationToken);
            if (repositoryResponse.Value != null && repositoryResponse.Success)
            {
                model.SetModel(repositoryResponse.Value);
            }

            return repositoryResponse.ToResponseModel(model);
        }

        public virtual async Task<IResponseModel<ViewModel>> UpdateAsync(ViewModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                return new ResponseModel<ViewModel>(false, false, CRMConstants.NullDataSent, new ViewModel());
            }

            var modelToUpdate = model.ToBaseModel();
            var repositoryResponse = await this._repository.UpdateAsync(modelToUpdate, cancellationToken);
            if (repositoryResponse.Value != null && repositoryResponse.Success)
            {
                model.SetModel(repositoryResponse.Value);
            }

            return repositoryResponse.ToResponseModel(model);
        }

        public virtual async Task<IResponseModel<ViewModel>> DeleteAsync(ViewModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                return new ResponseModel<ViewModel>(false, false, CRMConstants.NullDataSent, new ViewModel());
            }

            var repositoryResponse = await this._repository.DeleteAsync(model.Id, cancellationToken);
            if (repositoryResponse.Value != null && repositoryResponse.Success)
            {
                model.SetModel(repositoryResponse.Value);
            }

            return repositoryResponse.ToResponseModel(model);
        }

        public virtual async Task<IPagedList<ViewModel>> RetrieveListAsync(
            QueryStringParameters parameters, 
            Expression<Func<DataModel, bool>>? expression = null, 
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

            return await data.ToPagedViewModelList<ViewModel, DataModel>(parameters.PageNumber, parameters.PageSize);
        }
    }
}
