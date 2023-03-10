using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRM.Data
{
    /// <summary>
    /// The sub role entity
    /// </summary>
    public class SubRole : BaseDataModel<SubRole>, ISubRole
    {
        public SubRole()
        {
            this.ParentRole = new ApplicationRole();
            this.Role = new ApplicationRole();
        }

        /// <summary>
        /// The id of the parent role
        /// </summary>
        public int ParentRoleId { get; set; }

        /// <summary>
        /// The parent role entity
        /// </summary>
        [ForeignKey(nameof(ParentRoleId))]
        public ApplicationRole ParentRole { get; set; }

        /// <summary>
        /// The id of the sub role
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// The application role entity
        /// </summary>
        [ForeignKey(nameof(RoleId))]
        public ApplicationRole Role { get; set; }

        /// <summary>
        /// The override of the secure update to always return false
        /// </summary>
        /// <param name="model">The updated values</param>
        /// <returns>false</returns>
        public override bool SecureUpdate(SubRole model)
        {
            return false;
        }
    }
}
