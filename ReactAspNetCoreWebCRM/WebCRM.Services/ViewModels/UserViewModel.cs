using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class UserViewModel : SoftDeletedViewModel<User>, IUser
    {
        public UserViewModel() 
        {
        }

        public UserViewModel(User model)
        {
            this.SetModel(model);
        }

        public override void SetModel(User model)
        {
            if (model != null)
            {
                base.SetModel(model);
                this.Email = model.Email;
                this.Name = model.Name;
                this.UserType = model.UserType;

                if (model.ContractCustomers != null && model.ContractCustomers.Any())
                {
                    this.CustomerContracts = model.ContractCustomers.Select(x => new ContractCustomerViewModel(x)).ToList();
                }

                if (model.UserRoles != null && model.UserRoles.Any())
                {
                    this.RoleMemberships = model.UserRoles.Select(x => new RoleMemberViewModel(x)).ToList();
                }
            }
        }

        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int UserType { get; set; }

        public List<ContractCustomerViewModel> CustomerContracts { get; set; } = new List<ContractCustomerViewModel>();

        public List<RoleMemberViewModel> RoleMemberships { get; set; } = new List<RoleMemberViewModel>();

        public override User ToBaseModel()
        {
            var model = base.ToBaseModel();

            model.Email = this.Email;
            model.Name = this.Name;
            model.UserType = this.UserType;

            return model;
        }
    }
}
