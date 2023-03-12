namespace WebCRM.Data
{
    public interface IEntityApplicationRole
    {
        /// <summary>
        /// The id of the application role
        /// </summary>
        int ApplicationRoleId { get; set; }

        /// <summary>
        /// Grants Create access
        /// </summary>
        bool CanCreate { get; set; }

        /// <summary>
        /// Grants access to delete records from the entity table
        /// </summary>
        bool CanDelete { get; set; }

        /// <summary>
        /// Grants access to update the entity values
        /// </summary>
        bool CanUpdate { get; set; }

        /// <summary>
        /// Grants Access To View all records
        /// </summary>
        bool CanView { get; set; }

        /// <summary>
        /// The Entity table name
        /// </summary>
        string EntityName { get; set; }
    }
}