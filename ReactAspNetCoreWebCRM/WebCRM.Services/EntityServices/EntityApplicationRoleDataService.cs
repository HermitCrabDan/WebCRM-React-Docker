using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data.Entities;
using WebCRM.Data.Repositories;
using WebCRM.Services.ViewModels;

namespace WebCRM.Services.EntityServices
{
    public class EntityApplicationRoleDataService : BaseDataService<EntityApplicationRoleDto, EntityApplicationRole>
    {
        public EntityApplicationRoleDataService(IRepository<EntityApplicationRole> repository)
            : base(repository,
                  new List<string>
                  {
                      nameof(EntityApplicationRole.ApplicationRole),
                  },
                  new List<string>
                  {
                      nameof(EntityApplicationRole.ApplicationRole),
                  })
        {
        }
    }
}
