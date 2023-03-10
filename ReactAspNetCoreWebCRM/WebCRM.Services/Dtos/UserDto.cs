using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class UserDto : SoftDeletedDto<User>, IUser
    {
        public UserDto() 
        {
        }

        public UserDto(User model)
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
                    this.CustomerContracts = model.ContractCustomers.Select(x => new ContractCustomerDto(x)).ToList();
                }

                if (model.UserRoles != null && model.UserRoles.Any())
                {
                    this.RoleMemberships = model.UserRoles.Select(x => new RoleMemberDto(x)).ToList();
                }
            }
        }

        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int UserType { get; set; }

        public List<ContractCustomerDto> CustomerContracts { get; set; } = new List<ContractCustomerDto>();

        public List<RoleMemberDto> RoleMemberships { get; set; } = new List<RoleMemberDto>();

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
