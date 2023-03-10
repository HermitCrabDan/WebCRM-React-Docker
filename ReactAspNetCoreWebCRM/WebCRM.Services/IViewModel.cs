using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services
{
    public interface IViewModel<DataModel>
    {
        /// <summary>
        /// Sets the model values
        /// </summary>
        /// <param name="model">The data model</param>
        void SetModel(DataModel model);

        /// <summary>
        /// The data model Id
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// The data model created date
        /// </summary>
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// Returns the base data model
        /// </summary>
        /// <returns>The data model</returns>
        DataModel ToBaseModel();
    }
}
