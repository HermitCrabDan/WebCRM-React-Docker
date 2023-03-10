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
    public class ContractPaymentDataService : BaseDataService<ContractPaymentDto, ContractPayment>
    {
        public ContractPaymentDataService(IRepository<ContractPayment> repository)
            : base(repository,
                  new List<string>
                  {
                      nameof(ContractPayment.Contract),
                      nameof(ContractPayment.ContractMonthlyPayment),
                      nameof(ContractPayment.EnteredByUser),
                  },
                  new List<string>
                  {
                      nameof(ContractPayment.ContractMonthlyPayment),
                      nameof(ContractPayment.EnteredByUser),
                  })
        {
        }
    }
}
