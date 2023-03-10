using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;
using WebCRM.Services.Models;

namespace WebCRM.Services.Security
{
    public interface ISecurityService
    {
        /// <summary>
        /// Checks to if the user is in the role
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="roleName">the role name</param>
        /// <returns>A boolean value of true or false</returns>
        Task<bool> IsUserInRoleAsync(int userId, string roleName);

        /// <summary>
        /// Checks if the user can view all of the entity
        /// </summary>
        /// <typeparam name="DataModel">The entity type</typeparam>
        /// <param name="userId">The id of the user</param>
        /// <returns>A boolean value of true or false</returns>
        Task<bool> CanViewAllAsync<DataModel>(int userId);

        /// <summary>
        /// Checks if the user can create the entity
        /// </summary>
        /// <typeparam name="DataModel">The entity type</typeparam>
        /// <param name="userId">The id of the user</param>
        /// <returns>A boolean value of true or false</returns>
        Task<bool> CanCreateAsync<DataModel>(int userId);

        /// <summary>
        /// Checks if the user can delete the entity
        /// </summary>
        /// <typeparam name="DataModel">The entity type</typeparam>
        /// <param name="userId">The id of the user</param>
        /// <returns>A boolean value of true or false</returns>
        Task<bool> CanDeleteAsync<DataModel>(int userId);

        /// <summary>
        /// Checks if the user can update the entity
        /// </summary>
        /// <typeparam name="DataModel">The entity type</typeparam>
        /// <param name="userId">The id of the user</param>
        /// <returns>A boolean value of true or false</returns>
        Task<bool> CanUpdateAsync<DataModel>(int userId);
    }
}
