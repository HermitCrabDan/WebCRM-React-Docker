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
            this.ParentRoles = new List<SubRole>();
            this.SubRoles = new List<SubRole>();
            this.RoleMembers = new List<RoleMember>();
            this.EntityApplicationRoles = new List<EntityApplicationRole>();
        }

        /// <summary>
        /// The name of the role
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// The roles where this role is a sub role
        /// </summary>
        public virtual ICollection<SubRole> ParentRoles { get; set; }

        /// <summary>
        /// The sub roles of the role
        /// </summary>
        public virtual ICollection<SubRole> SubRoles { get; set; }

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
