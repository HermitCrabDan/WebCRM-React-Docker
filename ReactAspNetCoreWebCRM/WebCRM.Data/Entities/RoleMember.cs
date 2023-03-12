using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRM.Data
{
    /// <summary>
    /// The role member entity
    /// </summary>
    public class RoleMember : BaseDataModel<RoleMember>, IRoleMember
    {
        public RoleMember()
        {
            this.Role = new ApplicationRole();
            this.User = new User();
        }

        /// <summary>
        /// The id of the application role
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// The application role entity
        /// </summary>
        [ForeignKey("RoleId")]
        public virtual ApplicationRole Role { get; set; }

        /// <summary>
        /// The id of the user assigned to the role
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The user entity
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public override bool SecureUpdate(RoleMember model)
        {
            var propertiesChanged = this.RoleId != model.RoleId
                || this.UserId != model.UserId;

            if (propertiesChanged) 
            {
                this.UserId = model.UserId;
                this.RoleId = model.RoleId;
            }

            return propertiesChanged;
        }

        public override string ToString()
        {
            return $"RoleMember:{Id}=" +
                $"RoleId:{RoleId}," +
                $"UserId:{UserId}";
        }
    }
}
