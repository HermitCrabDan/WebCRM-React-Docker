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
    /// <summary>
    /// The base dto model to be inherited from
    /// </summary>
    /// <typeparam name="TEntity">The IDataModel Entity</typeparam>
    public abstract class BaseDto<TEntity> : IDto<TEntity> where TEntity : class, IDataModel<TEntity>, new()
    {
        /// <summary>
        /// Base constructor
        /// </summary>
        public BaseDto() { }

        /// <summary>
        /// Sets the model values
        /// </summary>
        /// <param name="model">The data model</param>
        public virtual void SetModel(TEntity model)
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
        public virtual TEntity ToBaseModel()
        {
            return new TEntity { Id = Id, CreatedDate = CreatedDate };
        }
    }

    public static class DtoExtensions
    {
        public static async Task<IPagedList<Dto>> ToPagedViewModelList<Dto, TEntity>(
            this IQueryable<TEntity> dataSource,
            int pageIndex,
            int pageSize,
            bool getOnlyTotalCount = false)
            where Dto : class, IDto<TEntity>, new()
        {
            if (dataSource == null)
                return new PagedList<Dto>(new List<Dto>(), pageIndex, pageSize);

            //min allowed page size is 1
            pageSize = Math.Max(pageSize, 1);

            var count = await dataSource.CountAsync();

            var data = new List<Dto>();

            if (!getOnlyTotalCount)
            {
                var sourceList = await dataSource.Skip(pageIndex * pageSize).Take(pageSize).AsQueryable().ToListAsync();
                if (sourceList.Any())
                {
                    foreach (var sourceItem in sourceList)
                    {
                        var model = new Dto();
                        model.SetModel(sourceItem);
                        data.Add(model);
                    }
                }
            }

            return new PagedList<Dto>(data, pageIndex, pageSize, count);
        }
    }
}
