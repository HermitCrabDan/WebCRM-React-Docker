namespace WebCRM.Data
{
    public interface ISubRole
    {
        /// <summary>
        /// The id of the parent role
        /// </summary>
        int ParentRoleId { get; set; }

        /// <summary>
        /// The id of the role
        /// </summary>
        int RoleId { get; set; }
    }
}