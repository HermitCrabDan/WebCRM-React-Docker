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

        public string EntityName { get; set; } = string.Empty;

        public bool CanCreate { get; set; }

        public bool CanView { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }

        public int ApplicationRoleId { get; set; }

        [ForeignKey(nameof(ApplicationRoleId))]
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
