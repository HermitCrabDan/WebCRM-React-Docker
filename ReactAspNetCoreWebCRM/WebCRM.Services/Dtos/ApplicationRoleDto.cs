using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class ApplicationRoleDto : SoftDeletedDto<ApplicationRole>, IApplicationRole
    {
        /// <summary>
        /// Base Constructor
        /// </summary>
        public ApplicationRoleDto() 
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationRole">The application role data model</param>
        public ApplicationRoleDto(ApplicationRole applicationRole) 
        {
            this.SetModel(applicationRole);
        }

        public override void SetModel(ApplicationRole model)
        {
            if (model != null)
            {
                base.SetModel(model);
                this.RoleName = model.RoleName;

                if (model.RoleMembers != null && model.RoleMembers.Any())
                {
                    this.RoleMembers = model.RoleMembers.Select(x => new RoleMemberDto(x)).ToList();
                }
            }
        }

        /// <summary>
        /// The name of the role
        /// </summary>
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// The members of the application role
        /// </summary>
        public List<RoleMemberDto> RoleMembers { get; set; } = new List<RoleMemberDto>();

        public override ApplicationRole ToBaseModel()
        {
            var role = base.ToBaseModel();
            role.RoleName = this.RoleName;
            return role;
        }
    }
}
