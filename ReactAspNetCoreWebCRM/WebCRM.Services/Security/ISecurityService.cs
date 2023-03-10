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
        Task<bool> IsUserInRoleAsync(int userId, string roleName);

        Task<bool> CanViewAllAsync<T>(int userId);

        Task<bool> CanCreateAsync<T>(int userId);

        Task<bool> CanDeleteAsync<T>(int userId);

        Task<bool> CanUpdateAsync<T>(int userId);
    }
}
