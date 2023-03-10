using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRM.Services.Security
{
    public interface IAuthorizationService
    {
        /// <summary>
        /// Gets the current user
        /// </summary>
        /// <returns>A dto for logged in user</returns>
        Task<ILoggedInUserDto> GetLoggedInUserAsync();
    }
}
