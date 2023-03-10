using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class RoleMemberDto : BaseDto<RoleMember>, IRoleMember
    {
        public RoleMemberDto() 
        {
        }

        public RoleMemberDto(RoleMember model)
        {
            this.SetModel(model);
        }

        public override void SetModel(RoleMember model)
        {
            if (model != null)
            {
                base.SetModel(model);
                this.RoleId = model.RoleId;
                this.UserId = model.UserId;

                if (model.Role != null)
                {
                    this.ApplicationRole = new ApplicationRoleDto(model.Role);
                }

                if (model.User != null)
                {
                    this.User = new UserDto(model.User);
                }
            }
        }

        public int RoleId { get; set; }
        public int UserId { get; set; }

        public ApplicationRoleDto ApplicationRole { get; set; } = new ApplicationRoleDto();

        public UserDto User { get; set; } = new UserDto();

        public override RoleMember ToBaseModel()
        {
            var model = base.ToBaseModel();

            model.RoleId = this.RoleId;
            model.UserId = this.UserId;

            return model;
        }
    }
}
