using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class RoleMemberViewModel : BaseViewModel<RoleMember>, IRoleMember
    {
        public RoleMemberViewModel() 
        {
        }

        public RoleMemberViewModel(RoleMember model)
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
                    this.ApplicationRole = new ApplicationRoleViewModel(model.Role);
                }

                if (model.User != null)
                {
                    this.User = new UserViewModel(model.User);
                }
            }
        }

        public int RoleId { get; set; }
        public int UserId { get; set; }

        public ApplicationRoleViewModel ApplicationRole { get; set; } = new ApplicationRoleViewModel();

        public UserViewModel User { get; set; } = new UserViewModel();

        public override RoleMember ToBaseModel()
        {
            var model = base.ToBaseModel();

            model.RoleId = this.RoleId;
            model.UserId = this.UserId;

            return model;
        }
    }
}
