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
    public abstract class BaseViewModel<T> : IViewModel<T> where T : class, IDataModel<T>, new()
    {
        public BaseViewModel() { }

        public virtual void SetModel(T model)
        {
            if (model != null)
            {
                Id = model.Id;
                CreatedDate = model.CreatedDate;
            }
        }

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual T ToBaseModel()
        {
            return new T { Id = Id, CreatedDate = CreatedDate };
        }
    }

    public static class ViewModelExtensions
    {
        public static async Task<IPagedList<T>> ToPagedViewModelList<T, U>(
            this IQueryable<U> dataSource,
            int pageIndex,
            int pageSize,
            bool getOnlyTotalCount = false)
            where T : class, IViewModel<U>, new()
        {
            if (dataSource == null)
                return new PagedList<T>(new List<T>(), pageIndex, pageSize);

            //min allowed page size is 1
            pageSize = Math.Max(pageSize, 1);

            var count = await dataSource.CountAsync();

            var data = new List<T>();

            if (!getOnlyTotalCount)
            {
                var sourceList = await dataSource.Skip(pageIndex * pageSize).Take(pageSize).AsQueryable().ToListAsync();
                if (sourceList.Any())
                {
                    foreach (var sourceItem in sourceList)
                    {
                        var model = new T();
                        model.SetModel(sourceItem);
                        data.Add(model);
                    }
                }
            }

            return new PagedList<T>(data, pageIndex, pageSize, count);
        }
    }
}
