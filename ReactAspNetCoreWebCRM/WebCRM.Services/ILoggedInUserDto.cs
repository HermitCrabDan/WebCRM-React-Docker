using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRM.Services
{
    public interface ILoggedInUserDto
    {
        /// <summary>
        /// The id of the logged in user
        /// </summary>
        int UserId { get; set; }

        /// <summary>
        /// The user name used to log in
        /// </summary>
        string UserName { get; set; }
    }
}
