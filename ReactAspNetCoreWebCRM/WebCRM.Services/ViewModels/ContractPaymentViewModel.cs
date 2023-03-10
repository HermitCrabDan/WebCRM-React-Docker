using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class ContractPaymentViewModel : SoftDeletedViewModel<ContractPayment>, IContractPayment
    {
        public ContractPaymentViewModel() 
        {
        }

        public ContractPaymentViewModel(ContractPayment model)
        {
            this.SetModel(model);
        }

        public override void SetModel(ContractPayment model)
        {
            if (model != null) 
            {
                base.SetModel(model);
                this.ContractId = model.ContractId;
                this.ContractMonthlyPaymentId = model.ContractMonthlyPaymentId;
                this.PaymentAmount = model.PaymentAmount;
                this.EnteredByUserId = model.EnteredByUserId;

                if (model.EnteredByUser != null)
                {
                    this.EnteredByUser = new UserViewModel(model.EnteredByUser);
                }
            }
        }

        public int ContractId { get; set; }
        public int? ContractMonthlyPaymentId { get; set; }
        public int EnteredByUserId { get; set; }
        public decimal PaymentAmount { get; set; }

        public UserViewModel EnteredByUser { get; set; } = new UserViewModel();

        public override ContractPayment ToBaseModel()
        {
            var model = base.ToBaseModel();

            model.ContractId = this.ContractId;
            model.ContractMonthlyPaymentId = this.ContractMonthlyPaymentId; 
            model.PaymentAmount = this.PaymentAmount;
            model.EnteredByUserId = this.EnteredByUserId;

            return model;
        }
    }
}
