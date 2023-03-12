using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    /// <summary>
    /// The RoleMember entity dto
    /// </summary>
    public class RoleMemberDto : BaseDto<RoleMember>, IRoleMember
    {
        /// <summary>
        /// Base constructor
        /// </summary>
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

        /// <summary>
        /// The Id of the role
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// The id of the user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The application role dto
        /// </summary>
        public ApplicationRoleDto ApplicationRole { get; set; } = new ApplicationRoleDto();

        /// <summary>
        /// The user dto
        /// </summary>
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
