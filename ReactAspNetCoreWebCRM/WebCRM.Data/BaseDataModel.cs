using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebCRM.Common;

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
        /// base implementation of the secure update
        /// </summary>
        /// <param name="model">The model with the updated values</param>
        /// <returns>A boolean value indicating whether any properties where changed</returns>
        public virtual bool SecureUpdate(T model)
        {
            var propertiesChanged = false;
            var modelType = typeof(T);
            foreach (var modelProperty in modelType.GetProperties()) 
            {
                if (modelProperty.Name != nameof(Id)
                    && modelProperty.Name != nameof(SoftDeletedModel.DeletedDate)
                    && modelProperty.Name != nameof(CreatedDate)
                    && modelProperty.CanRead
                    && modelProperty.CanWrite
                    && modelProperty.PropertyType.IsPublic
                    && !modelProperty.PropertyType.IsClass
                    && !modelProperty.PropertyType.IsArray
                    && CRMConstants.CRMBaseTypes.Contains(modelProperty.PropertyType))
                {
                    var modelValue = modelProperty.GetValue(model);
                    var valueChanged = modelProperty.GetValue(this) != modelValue;
                    if (valueChanged)
                    {
                        modelProperty.SetValue(this, modelValue);
                        propertiesChanged = true;
                    }
                }
            }

            return propertiesChanged;
        }

        /// <summary>
        /// A better string for logging information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var modelType = typeof(T);
            stringBuilder.Append("{ ");
            stringBuilder.Append(modelType.Name);
            stringBuilder.Append(": {");
            foreach (var modelProperty in modelType.GetProperties())
            {
                if (modelProperty.CanRead
                    && modelProperty.PropertyType.IsPublic
                    && !modelProperty.PropertyType.IsClass
                    && !modelProperty.PropertyType.IsArray
                    && CRMConstants.CRMBaseTypes.Contains(modelProperty.PropertyType))
                {
                    stringBuilder.Append(modelProperty.Name);
                    stringBuilder.Append(": ");
                    var modelValue = modelProperty.GetValue(this);
                    if (modelProperty.PropertyType == typeof(DateTime)
                        || modelProperty.PropertyType == typeof(DateTime?))
                    {
                        stringBuilder.AppendFormat("{0:yyyy-MM-dd}", modelValue);
                    }
                    else
                    {
                        stringBuilder.Append(modelValue);
                    }
                    stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append("}}");
            return stringBuilder.ToString();
        }
    }
}
