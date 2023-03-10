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
    public class UserDataService : BaseDataService<UserDto, User>
    {
        public UserDataService(IRepository<User> repository)
            : base(
                  repository,
                  new List<string>
                  {
                      nameof(User.ContractCustomers),
                      nameof(User.UserRoles),
                  },
                  new List<string>())
        {
        }
    }
}
