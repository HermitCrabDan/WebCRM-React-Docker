using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services
{
    public abstract class SoftDeletedViewModel<T> : BaseViewModel<T>, ISoftDeleted where T : class, IDataModel<T>, ISoftDeleted, new()
    {
        public SoftDeletedViewModel() { }

        public override void SetModel(T model)
        {
            if (model != null)
            {
                base.SetModel(model);
                DeletedDate = model.DeletedDate;
            }
        }

        public DateTime? DeletedDate { get; set; }

        public override T ToBaseModel()
        {
            var model = base.ToBaseModel();
            model.DeletedDate = DeletedDate;
            return model;
        }
    }
}
