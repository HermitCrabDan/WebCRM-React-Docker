using System.ComponentModel.DataAnnotations;

namespace WebCRM.Data
{
    /// <summary>
    /// The base data model
    /// </summary>
    /// <typeparam name="T">The database entity</typeparam>
    public abstract class BaseDataModel<T> : IDataModel<T> where T : class, new()
    {
        /// <summary>
        /// Primary Key for the entity
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The date the entity is created
        /// </summary>
        public virtual DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date the entity was last modified
        /// </summary>
        public virtual DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Secure entity update for repository calls
        /// </summary>
        /// <param name="model">The model with the updated values</param>
        /// <returns>A boolean value indicating whether any properties where changed</returns>
        public virtual bool SecureUpdate(T model)
        {
            return false;
        }
    }
}
