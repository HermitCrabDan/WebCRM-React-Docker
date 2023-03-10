using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class ContractCustomerViewModel : SoftDeletedViewModel<ContractCustomer>, IContractCustomer
    {
        public ContractCustomerViewModel() { }

        public ContractCustomerViewModel(ContractCustomer model)
        {
            this.SetModel(model);
        }

        public override void SetModel(ContractCustomer model)
        {
            if (model != null)
            {
                base.SetModel(model);
                this.ContractId = model.ContractId;
                this.CustomerId = model.CustomerId;
            }
        }

        public int ContractId { get; set; }
        public int CustomerId { get; set; }

        public override ContractCustomer ToBaseModel()
        {
            var model = base.ToBaseModel();
            model.ContractId = this.ContractId;
            model.CustomerId = this.CustomerId;
            return model;
        }
    }
}
