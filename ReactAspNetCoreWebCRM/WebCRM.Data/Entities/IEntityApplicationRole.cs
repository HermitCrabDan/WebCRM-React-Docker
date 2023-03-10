namespace WebCRM.Data.Entities
{
    public interface IEntityApplicationRole
    {
        int ApplicationRoleId { get; set; }
        bool CanCreate { get; set; }
        bool CanDelete { get; set; }
        bool CanUpdate { get; set; }
        bool CanView { get; set; }
        string EntityName { get; set; }
    }
}