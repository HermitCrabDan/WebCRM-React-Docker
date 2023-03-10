using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Security
{
    public interface ICustomerSecurityService
    {
        /// <summary>
        /// Checks if the customer can view the specific entity
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <param name="userId">the user id</param>
        /// <param name="entityId">the entity id</param>
        /// <returns>A boolean value of true or false</returns>
        Task<bool> CanCustomerViewEntityAsync<TEntity>(int userId, int entityId) where TEntity : class, IDataModel<TEntity>, new();
    }
}
