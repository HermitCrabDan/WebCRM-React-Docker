using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class SubRoleViewModel : BaseViewModel<SubRole>, ISubRole
    {
        public SubRoleViewModel() { }

        public SubRoleViewModel(SubRole model)
        {
            this.SetModel(model);
        }

        public override void SetModel(SubRole model)
        {
            if (model != null)
            {
                base.SetModel(model);
                this.ParentRoleId = model.ParentRoleId;
                this.RoleId = model.RoleId;

                if (model.ParentRole != null)
                {
                    this.ParentRole = new ApplicationRoleViewModel(model.ParentRole);
                }

                if (model.Role != null)
                {
                    this.Role = new ApplicationRoleViewModel(model.Role);
                }
            }
        }

        public int ParentRoleId { get; set; }
        public int RoleId { get; set; }

        public ApplicationRoleViewModel ParentRole { get; set; } = new ApplicationRoleViewModel();

        public ApplicationRoleViewModel Role { get; set; } = new ApplicationRoleViewModel();

        public override SubRole ToBaseModel()
        {
            var model = base.ToBaseModel();

            model.ParentRoleId = this.ParentRoleId;
            model.RoleId = this.RoleId;

            return model;
        }
    }
}
