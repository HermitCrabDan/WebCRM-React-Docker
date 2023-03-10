using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;
using WebCRM.Data.Entities;

namespace WebCRM.Services.Security
{
    public class SecurityService : ISecurityService
    {
        private readonly IRepository<ApplicationRole> _applicationRoleRepository;
        private readonly IRepository<EntityApplicationRole> _entityApplicationRoleRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationRoleRepository">The repository for the application roles</param>
        /// <param name="entityApplicationRoleRepository">The repository for entity application role</param>
        public SecurityService(
            IRepository<ApplicationRole> applicationRoleRepository,
            IRepository<EntityApplicationRole> entityApplicationRoleRepository) 
        {
            this._applicationRoleRepository = applicationRoleRepository;
            this._entityApplicationRoleRepository = entityApplicationRoleRepository;
        }

        /// <summary>
        /// Checks if the user can create the entity
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <param name="userId">The id of the user</param>
        /// <returns>A boolean value of true or false</returns>
        public async Task<bool> CanCreateAsync<TEntity>(int userId)
            where TEntity : class, IDataModel<TEntity>, new()
        {
            var entityName = typeof(TEntity).Name;
            return await this._entityApplicationRoleRepository.RepositoryTable
                .AnyAsync(x => x.CanCreate && x.EntityName == entityName && x.ApplicationRole.RoleMembers.Any(y => y.UserId == userId));

        }

        /// <summary>
        /// Checks if the user can delete the entity
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <param name="userId">The id of the user</param>
        /// <returns>A boolean value of true or false</returns>
        public async Task<bool> CanDeleteAsync<TEntity>(int userId)
            where TEntity : class, IDataModel<TEntity>, new()
        {
            var entityName = typeof(TEntity).Name;
            return await this._entityApplicationRoleRepository.RepositoryTable
                .AnyAsync(x => x.CanDelete && x.EntityName == entityName && x.ApplicationRole.RoleMembers.Any(y => y.UserId == userId));
        }

        /// <summary>
        /// Checks if the user can update the entity
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <param name="userId">The id of the user</param>
        /// <returns>A boolean value of true or false</returns>
        public async Task<bool> CanUpdateAsync<TEntity>(int userId)
            where TEntity : class, IDataModel<TEntity>, new()
        {
            var entityName = typeof(TEntity).Name;
            return await this._entityApplicationRoleRepository.RepositoryTable
                .AnyAsync(x => x.CanUpdate && x.EntityName == entityName && x.ApplicationRole.RoleMembers.Any(y => y.UserId == userId));
        }

        /// <summary>
        /// Checks if the user can view all of the entity
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <param name="userId">The id of the user</param>
        /// <returns>A boolean value of true or false</returns>
        public async Task<bool> CanViewAllAsync<TEntity>(int userId)
            where TEntity : class, IDataModel<TEntity>, new()
        {
            var entityName = typeof(TEntity).Name;
            return await this._entityApplicationRoleRepository.RepositoryTable
                .AnyAsync(x => x.CanView && x.EntityName == entityName && x.ApplicationRole.RoleMembers.Any(y => y.UserId == userId));
        }

        /// <summary>
        /// Checks if the user is in the role
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="roleName">the name of the role</param>
        /// <returns>A boolean value of true or false</returns>
        public async Task<bool> IsUserInRoleAsync(int userId, string roleName)
        {
            return await this._applicationRoleRepository.RepositoryTable
                .AnyAsync(x => x.RoleName == roleName && x.RoleMembers.Any(y => y.UserId == userId));
        }
    }
}
