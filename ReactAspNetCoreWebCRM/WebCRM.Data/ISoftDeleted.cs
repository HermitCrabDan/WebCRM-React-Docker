namespace WebCRM.Data
{
    public interface ISoftDeleted
    {
        /// <summary>
        /// The date the object was marked as deleted
        /// </summary>
        DateTime? DeletedDate { get; set; }
    }
}
