using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class ContractMonthlyPaymentViewModel : SoftDeletedViewModel<ContractMonthlyPayment>, IContractMonthlyPayment
    {
        public ContractMonthlyPaymentViewModel() { }

        public ContractMonthlyPaymentViewModel(ContractMonthlyPayment model)
        {
            this.SetModel(model);
        }

        public override void SetModel(ContractMonthlyPayment model)
        {
            if (model != null)
            {
                base.SetModel(model);
                this.ContractId = model.ContractId;
                this.DueDate = model.DueDate;
                this.MonthlyPaymentAmountDue = model.MonthlyPaymentAmountDue;
                this.PaymentCompletionDate = model.PaymentCompletionDate;
                this.PaymentSkipedDate = model.PaymentSkipedDate;
                this.PaymentSkippedByUserId = model.PaymentSkippedByUserId;

                if (model.PaymentSkippedByUser != null)
                {
                    this.PaymentSkippedByUser = new UserViewModel(model.PaymentSkippedByUser);
                }
            }
        }

        public int ContractId { get; set; }
        
        public DateTime DueDate { get; set; }
        
        public decimal MonthlyPaymentAmountDue { get; set; }
        
        public DateTime? PaymentCompletionDate { get; set; }
        
        public DateTime? PaymentSkipedDate { get; set; }
        
        public int? PaymentSkippedByUserId { get; set; }

        public UserViewModel PaymentSkippedByUser { get; set; } = new UserViewModel();

        public override ContractMonthlyPayment ToBaseModel()
        {
            var model = base.ToBaseModel();
            
            model.ContractId = this.ContractId;
            model.DueDate = this.DueDate;
            model.MonthlyPaymentAmountDue = this.MonthlyPaymentAmountDue;
            model.PaymentCompletionDate = this.PaymentCompletionDate;
            model.PaymentSkipedDate = this.PaymentSkipedDate;
            model.PaymentSkippedByUserId = this.PaymentSkippedByUserId;

            return model;
        }
    }
}
