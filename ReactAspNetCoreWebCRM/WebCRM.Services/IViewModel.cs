using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services
{
    public interface IViewModel<T>
    {
        void SetModel(T model);

        int Id { get; set; }

        DateTime CreatedDate { get; set; }

        T ToBaseModel();
    }
}
