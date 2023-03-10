using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRM.Data.Repositories
{
    /// <summary>
    /// Base repository for users
    /// </summary>
    public class UserRepository: BaseRepository<User>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataContext">The data context</param>
        /// <param name="logger">The logger</param>
        public UserRepository(ICRMDataContext dataContext, ILogger logger) 
            : base(dataContext, logger) 
        {
        }
    }
}
