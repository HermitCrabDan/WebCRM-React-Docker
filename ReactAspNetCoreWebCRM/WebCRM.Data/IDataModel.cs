namespace WebCRM.Data
{
    public interface IDataModel<T> where T : class, new()
    {
        /// <summary>
        /// The primary id of the model
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// The date the entity was added to the database
        /// </summary>
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date the entity was last updated
        /// </summary>
        DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// A limited update feature
        /// </summary>
        /// <param name="model">The updated values</param>
        /// <returns>A boolean value indicating whether any changes where made</returns>
        bool SecureUpdate(T model);
    }
}
