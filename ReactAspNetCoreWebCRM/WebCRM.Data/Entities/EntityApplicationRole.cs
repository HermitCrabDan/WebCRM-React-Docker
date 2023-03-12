using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRM.Data.Entities
{
    public class EntityApplicationRole : BaseDataModel<EntityApplicationRole>, IEntityApplicationRole
    {
        public EntityApplicationRole()
        {
            this.ApplicationRole = new ApplicationRole();
        }

        /// <summary>
        /// The Entity table name
        /// </summary>
        public string EntityName { get; set; } = string.Empty;

        /// <summary>
        /// Grants Create access
        /// </summary>
        public bool CanCreate { get; set; }

        /// <summary>
        /// Grants Access To View all records
        /// </summary>
        public bool CanView { get; set; }

        /// <summary>
        /// Grants access to update the entity values
        /// </summary>
        public bool CanUpdate { get; set; }

        /// <summary>
        /// Grants access to delete records from the entity table
        /// </summary>
        public bool CanDelete { get; set; }

        /// <summary>
        /// The id of the application role
        /// </summary>
        public int ApplicationRoleId { get; set; }

        /// <summary>
        /// The application role entity
        /// </summary>
        [ForeignKey(nameof(ApplicationRoleId))]
        public virtual ApplicationRole ApplicationRole { get; set; }

        public override bool SecureUpdate(EntityApplicationRole model)
        {
            var propertiesChanged = this.CanCreate != model.CanCreate
                || this.CanUpdate != model.CanUpdate
                || this.CanView != model.CanView
                || this.CanDelete != model.CanDelete
                || this.ApplicationRoleId != model.ApplicationRoleId
                || this.EntityName != model.EntityName;

            if (propertiesChanged)
            {
                this.CanUpdate = model.CanUpdate;
                this.CanView = model.CanView;
                this.CanDelete = model.CanDelete;
                this.CanCreate = model.CanCreate;
                this.ApplicationRoleId = model.ApplicationRoleId;
                this.EntityName = model.EntityName;
            }

            return propertiesChanged;
        }

        public override string ToString()
        {
            return $"EntityApplicationRole:{Id}=" +
                $"ApplicationRoleId:{ApplicationRoleId}," +
                $"EntityName:{EntityName},CanUpdate," +
                $"CanCreate:{CanCreate}," +
                $"CanView:{CanView}," +
                $"CanUpdate:{CanUpdate}," +
                $"CanDelete:{CanDelete}";
        }
    }
}
