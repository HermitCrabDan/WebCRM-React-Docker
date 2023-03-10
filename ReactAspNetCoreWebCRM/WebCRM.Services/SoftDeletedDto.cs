using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services
{
    public abstract class SoftDeletedDto<DataModel> : BaseDto<DataModel>, ISoftDeleted where DataModel : class, IDataModel<DataModel>, ISoftDeleted, new()
    {
        public SoftDeletedDto() { }

        /// <summary>
        /// Sets the model values
        /// </summary>
        /// <param name="model">The data model</param>
        public override void SetModel(DataModel model)
        {
            if (model != null)
            {
                base.SetModel(model);
                DeletedDate = model.DeletedDate;
            }
        }

        /// <summary>
        /// The date the entity was softt deleted
        /// </summary>
        public DateTime? DeletedDate { get; set; }

        /// <summary>
        /// Returns the base data model
        /// </summary>
        /// <returns>The data model</returns>
        public override DataModel ToBaseModel()
        {
            var model = base.ToBaseModel();
            model.DeletedDate = DeletedDate;
            return model;
        }
    }
}
