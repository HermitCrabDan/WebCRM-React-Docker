namespace WebCRM.Data
{
    public interface IRoleMember
    {
        /// <summary>
        /// The Id of the role
        /// </summary>
        int RoleId { get; set; }

        /// <summary>
        /// The id of the user
        /// </summary>
        int UserId { get; set; }
    }
}