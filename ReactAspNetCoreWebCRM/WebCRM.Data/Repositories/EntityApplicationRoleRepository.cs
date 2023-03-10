using Microsoft.Extensions.Logging;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data.Entities;

namespace WebCRM.Data.Repositories
{
    public class EntityApplicationRoleRepository: BaseRepository<EntityApplicationRole>
    {
        public EntityApplicationRoleRepository(ICRMDataContext dataContext, ILogger logger)
            : base(dataContext, logger) 
        {
        }
    }
}
