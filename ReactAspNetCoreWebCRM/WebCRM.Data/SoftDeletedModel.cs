namespace WebCRM.Data
{
    public class SoftDeletedModel : ISoftDeleted
    {
        /// <summary>
        /// The date the entity is flagged as deleted
        /// </summary>
        public DateTime? DeletedDate { get; set; }
    }
}
