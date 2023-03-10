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

        public SecurityService(
            IRepository<ApplicationRole> applicationRoleRepository,
            IRepository<EntityApplicationRole> entityApplicationRoleRepository) 
        {
            this._applicationRoleRepository = applicationRoleRepository;
            this._entityApplicationRoleRepository = entityApplicationRoleRepository;
        }

        public async Task<bool> CanCreateAsync<T>(int userId)
        {
            var entityName = typeof(T).Name;
            return await this._entityApplicationRoleRepository.RepositoryTable
                .AnyAsync(x => x.CanCreate && x.EntityName == entityName && x.ApplicationRole.RoleMembers.Any(y => y.UserId == userId));

        }

        public async Task<bool> CanDeleteAsync<T>(int userId)
        {
            var entityName = typeof(T).Name;
            return await this._entityApplicationRoleRepository.RepositoryTable
                .AnyAsync(x => x.CanDelete && x.EntityName == entityName && x.ApplicationRole.RoleMembers.Any(y => y.UserId == userId));
        }

        public async Task<bool> CanUpdateAsync<T>(int userId)
        {
            var entityName = typeof(T).Name;
            return await this._entityApplicationRoleRepository.RepositoryTable
                .AnyAsync(x => x.CanUpdate && x.EntityName == entityName && x.ApplicationRole.RoleMembers.Any(y => y.UserId == userId));
        }

        public async Task<bool> CanViewAllAsync<T>(int userId)
        {
            var entityName = typeof(T).Name;
            return await this._entityApplicationRoleRepository.RepositoryTable
                .AnyAsync(x => x.CanView && x.EntityName == entityName && x.ApplicationRole.RoleMembers.Any(y => y.UserId == userId));
        }

        public async Task<bool> IsUserInRoleAsync(int userId, string roleName)
        {
            return await this._applicationRoleRepository.RepositoryTable
                .AnyAsync(x => x.RoleName == roleName && x.RoleMembers.Any(y => y.UserId == userId));
        }
    }
}
