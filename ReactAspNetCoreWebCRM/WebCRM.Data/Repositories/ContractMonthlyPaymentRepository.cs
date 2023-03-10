using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRM.Data.Repositories
{
    /// <summary>
    /// The base repository for the ContractMonthlyPayment
    /// </summary>
    public class ContractMonthlyPaymentRepository: BaseRepository<ContractMonthlyPayment>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataContext">the data context</param>
        /// <param name="logger">the logger</param>
        public ContractMonthlyPaymentRepository(ICRMDataContext dataContext, ILogger logger) 
            : base(dataContext, logger) 
        {
        }
    }
}
