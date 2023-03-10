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
    public class ContractMonthlyPaymentDataService : BaseDataService<ContractMonthlyPaymentDto, ContractMonthlyPayment>
    {
        public ContractMonthlyPaymentDataService(IRepository<ContractMonthlyPayment> repository)
            : base(repository,
                  new List<string>
                  {
                      nameof(ContractMonthlyPayment.PaymentSkippedByUser),
                      nameof(ContractMonthlyPayment.Contract),
                      nameof(ContractMonthlyPayment.ContractPayments),
                  },
                  new List<string>
                  {
                      nameof(ContractMonthlyPayment.PaymentSkippedByUser),
                      nameof(ContractMonthlyPayment.ContractPayments),
                  })
        {
        }
    }
}
