using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;
using WebCRM.Data.Entities;
using WebCRM.Services.Models;

namespace WebCRM.Services.ViewModels
{
    public class EntityApplicationRoleDto : BaseDto<EntityApplicationRole>, IEntityApplicationRole
    {
        public EntityApplicationRoleDto() { }

        public EntityApplicationRoleDto(EntityApplicationRole model)
        {
            this.SetModel(model);
        }

        /// <summary>
        /// The id of the application role
        /// </summary>
        public int ApplicationRoleId { get; set; }

        /// <summary>
        /// Grants Create access
        /// </summary>
        public bool CanCreate { get; set; }

        /// <summary>
        /// Grants access to delete records from the entity table
        /// </summary>
        public bool CanDelete { get; set; }

        /// <summary>
        /// Grants access to update the entity values
        /// </summary>
        public bool CanUpdate { get; set; }

        /// <summary>
        /// Grants Access To View all records
        /// </summary>
        public bool CanView { get; set; }

        /// <summary>
        /// The Entity table name
        /// </summary>
        public string EntityName { get; set; } = string.Empty;

        public virtual ApplicationRoleDto ApplicationRole { get; set; } = new ApplicationRoleDto();

        public override void SetModel(EntityApplicationRole model)
        {
            if (model != null)
            {
                base.SetModel(model);

                this.CanCreate = model.CanCreate;
                this.CanView = model.CanView;
                this.CanUpdate = model.CanUpdate;
                this.CanDelete = model.CanDelete;
                this.ApplicationRoleId = model.ApplicationRoleId;
                this.EntityName = model.EntityName; 

                if (model.ApplicationRole != null) 
                {
                    this.ApplicationRole = new ApplicationRoleDto(model.ApplicationRole);
                }
            }
        }

        public override EntityApplicationRole ToBaseModel()
        {
            var model = base.ToBaseModel();

            model.CanCreate = this.CanCreate;
            model.CanView = this.CanView;
            model.CanUpdate = this.CanUpdate;
            model.CanDelete = this.CanDelete;
            model.ApplicationRoleId = this.ApplicationRoleId;
            model.EntityName = this.EntityName;

            return model;
        }
    }
}
