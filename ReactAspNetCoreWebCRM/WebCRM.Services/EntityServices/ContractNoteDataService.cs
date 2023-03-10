using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;
using WebCRM.Data.Repositories;
using WebCRM.Services.Models;

namespace WebCRM.Services.EntityServices
{
    public class ContractNoteDataService : BaseDataService<ContractNoteDto, ContractNote>
    {
        public ContractNoteDataService(IRepository<ContractNote> repository)
            : base(repository,
                  new List<string>
                  {
                      nameof(ContractNote.Contract),
                  },
                  new List<string>
                  {
                  })
        {
        }
    }
}
