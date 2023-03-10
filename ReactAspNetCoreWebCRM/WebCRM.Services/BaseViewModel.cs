using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Common;
using WebCRM.Data;

namespace WebCRM.Services
{
    public abstract class BaseViewModel<DataModel> : IViewModel<DataModel> where DataModel : class, IDataModel<DataModel>, new()
    {
        public BaseViewModel() { }

        /// <summary>
        /// Sets the model values
        /// </summary>
        /// <param name="model">The data model</param>
        public virtual void SetModel(DataModel model)
        {
            if (model != null)
            {
                Id = model.Id;
                CreatedDate = model.CreatedDate;
            }
        }

        /// <summary>
        /// The data model Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The data model created date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Returns the base data model
        /// </summary>
        /// <returns>The data model</returns>
        public virtual DataModel ToBaseModel()
        {
            return new DataModel { Id = Id, CreatedDate = CreatedDate };
        }
    }

    public static class ViewModelExtensions
    {
        public static async Task<IPagedList<ViewModel>> ToPagedViewModelList<ViewModel, DataModel>(
            this IQueryable<DataModel> dataSource,
            int pageIndex,
            int pageSize,
            bool getOnlyTotalCount = false)
            where ViewModel : class, IViewModel<DataModel>, new()
        {
            if (dataSource == null)
                return new PagedList<ViewModel>(new List<ViewModel>(), pageIndex, pageSize);

            //min allowed page size is 1
            pageSize = Math.Max(pageSize, 1);

            var count = await dataSource.CountAsync();

            var data = new List<ViewModel>();

            if (!getOnlyTotalCount)
            {
                var sourceList = await dataSource.Skip(pageIndex * pageSize).Take(pageSize).AsQueryable().ToListAsync();
                if (sourceList.Any())
                {
                    foreach (var sourceItem in sourceList)
                    {
                        var model = new ViewModel();
                        model.SetModel(sourceItem);
                        data.Add(model);
                    }
                }
            }

            return new PagedList<ViewModel>(data, pageIndex, pageSize, count);
        }
    }
}
