using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class ApplicationRoleViewModel : SoftDeletedViewModel<ApplicationRole>, IApplicationRole
    {
        public ApplicationRoleViewModel() 
        {
        }

        public ApplicationRoleViewModel(ApplicationRole applicationRole) 
        {
            this.SetModel(applicationRole);
        }

        public override void SetModel(ApplicationRole model)
        {
            if (model != null)
            {
                base.SetModel(model);
                this.RoleName = model.RoleName;

                if (model.SubRoles != null && model.SubRoles.Any())
                {
                    this.SubRoles = model.SubRoles.Select(x => new SubRoleViewModel(x)).ToList();
                }

                if (model.RoleMembers != null && model.RoleMembers.Any())
                {
                    this.RoleMembers = model.RoleMembers.Select(x => new RoleMemberViewModel(x)).ToList();
                }
            }
        }

        public string RoleName { get; set; } = string.Empty;

        public List<SubRoleViewModel> SubRoles { get; set; } = new List<SubRoleViewModel>();

        public List<RoleMemberViewModel> RoleMembers { get; set; } = new List<RoleMemberViewModel>();

        public override ApplicationRole ToBaseModel()
        {
            var role = base.ToBaseModel();
            role.RoleName = this.RoleName;
            return role;
        }
    }
}
