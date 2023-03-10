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
    public class RoleMemberDataService : BaseDataService<RoleMemberViewModel, RoleMember>
    {
        public RoleMemberDataService(IRepository<RoleMember> repository)
            : base(repository,
                  new List<string>
                  {
                      nameof(RoleMember.Role),
                      nameof(RoleMember.User),
                  },
                  new List<string>
                  {
                      nameof(RoleMember.User),
                  })
        {
        }
    }
}
