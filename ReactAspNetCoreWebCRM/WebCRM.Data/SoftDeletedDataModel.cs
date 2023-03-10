namespace WebCRM.Data
{
    public abstract class SoftDeletedDataModel<T>: BaseDataModel<T>, ISoftDeleted
        where T : class, new()
    {
        /// <summary>
        /// The date the entity is flagged as deleted
        /// </summary>
        public DateTime? DeletedDate { get; set; }
    }
}
