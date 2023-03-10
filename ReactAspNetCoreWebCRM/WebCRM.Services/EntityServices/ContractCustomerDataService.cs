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
    public class ContractCustomerDataService : BaseDataService<ContractCustomerViewModel, ContractCustomer>
    {
        public ContractCustomerDataService(IRepository<ContractCustomer> repository)
            : base(repository,
                  new List<string>
                  {
                      nameof(ContractCustomer.Customer),
                      nameof(ContractCustomer.Contract),
                  },
                  new List<string>
                  {
                      nameof(ContractCustomer.Customer),
                  })
        {
        }
    }
}
