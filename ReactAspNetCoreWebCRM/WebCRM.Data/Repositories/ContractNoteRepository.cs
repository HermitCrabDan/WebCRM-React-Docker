using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRM.Data.Repositories
{
    /// <summary>
    /// The base repository for contract notes
    /// </summary>
    public class ContractNoteRepository: BaseRepository<ContractNote>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataContext">The data context</param>
        /// <param name="logger">The logger</param>
        public ContractNoteRepository(ICRMDataContext dataContext, ILogger logger) 
            : base(dataContext, logger)
        {
        }
    }
}
