using WebCRM.Data.Entities;

namespace WebCRM.Data
{
    /// <summary>
    /// The application role entity
    /// </summary>
    public class ApplicationRole : SoftDeletedDataModel<ApplicationRole>, IApplicationRole
    {
        public ApplicationRole()
        {
            this.RoleName = string.Empty;
            this.RoleMembers = new List<RoleMember>();
            this.EntityApplicationRoles = new List<EntityApplicationRole>();
        }

        /// <summary>
        /// The name of the role
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// The users in the role
        /// </summary>
        public virtual ICollection<RoleMember> RoleMembers { get; set; }

        /// <summary>
        /// The entities associated with the role
        /// </summary>
        public virtual ICollection<EntityApplicationRole> EntityApplicationRoles { get; set; }
    }
}
