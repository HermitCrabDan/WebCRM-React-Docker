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
    public class ContractDataService : BaseDataService<ContractDto, Contract>
    {
        public ContractDataService(IRepository<Contract> repository)
            : base(
                  repository,
                  new List<string>
                  {
                      nameof(Contract.ContractCustomers),
                      nameof(Contract.ContractPayments),
                      nameof(Contract.ContractNotes),
                      nameof(Contract.ContractMonthlyPayments)
                  },
                  new List<string>
                  {
                      nameof(Contract.ContractCustomers),
                      nameof(Contract.ContractPayments),
                      nameof(Contract.ContractMonthlyPayments)
                  })
        {
        }
    }
}
