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
                this.Id = model.Id;
                this.CreatedDate = model.CreatedDate;
                this.ModifiedDate = model.ModifiedDate;
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
        /// The date the entity was last modified
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Returns the base data model
        /// </summary>
        /// <returns>The data model</returns>
        public virtual TEntity ToBaseModel()
        {
            return new TEntity 
            { 
                Id = this.Id, 
                CreatedDate = this.CreatedDate, 
                ModifiedDate = this.ModifiedDate ,
            };
        }
    }

    public static class DtoExtensions
    {
        /// <summary>
        /// Creates a paged list of the dto based on the base entity
        /// </summary>
        /// <typeparam name="Dto">The view model</typeparam>
        /// <typeparam name="TEntity">The base model</typeparam>
        /// <param name="dataSource">The entity table</param>
        /// <param name="pageIndex">the page index</param>
        /// <param name="pageSize">the page size</param>
        /// <returns>PagedList of the dto</returns>
        public static async Task<IPagedList<Dto>> ToPagedViewModelList<Dto, TEntity>(
            this IQueryable<TEntity> dataSource,
            int pageIndex,
            int pageSize)
            where Dto : class, IDto<TEntity>, new()
        {
            if (dataSource == null)
                return new PagedList<Dto>(new List<Dto>(), pageIndex, pageSize);

            //min allowed page size is 1
            pageSize = Math.Max(pageSize, 1);

            var count = await dataSource.CountAsync();

            var data = new List<Dto>();

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

            return new PagedList<Dto>(data, pageIndex, pageSize, count);
        }
    }
}
