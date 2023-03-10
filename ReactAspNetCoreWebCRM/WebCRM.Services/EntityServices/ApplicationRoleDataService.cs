using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;
using WebCRM.Data.Repositories;
using WebCRM.Services.Models;

namespace WebCRM.Services.EntityServices
{
    public class ApplicationRoleDataService : BaseDataService<ApplicationRoleDto, ApplicationRole>
    {
        public ApplicationRoleDataService(IRepository<ApplicationRole> repository)
            : base(repository,
                  new List<string>
                  {
                      nameof(ApplicationRole.RoleMembers),
                  },
                  new List<string>
                  {
                  })
        {
        }
    }
}
