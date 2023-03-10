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
    public class SubRoleDataService : BaseDataService<SubRoleViewModel, SubRole>
    {
        public SubRoleDataService(IRepository<SubRole> repository)
            : base(repository,
                  new List<string>
                  {
                      nameof(SubRole.ParentRole),
                      nameof(SubRole.Role),
                  },
                  new List<string>
                  {
                      nameof(SubRole.Role)
                  })
        {
        }
    }
}
