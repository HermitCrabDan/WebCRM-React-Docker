using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class ContractMonthlyPaymentDto : SoftDeletedDto<ContractMonthlyPayment>, IContractMonthlyPayment
    {
        public ContractMonthlyPaymentDto() { }

        public ContractMonthlyPaymentDto(ContractMonthlyPayment model)
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

                if (model.Contract != null)
                {
                    this.Contract = new ContractDto(model.Contract);
                }

                if (model.PaymentSkippedByUser != null)
                {
                    this.PaymentSkippedByUser = new UserDto(model.PaymentSkippedByUser);
                }

                if (model.ContractPayments != null && model.ContractPayments.Any())
                {
                    this.ContractPayments = model.ContractPayments.Select(x => new ContractPaymentDto(x)).ToList();
                }
            }
        }

        /// <summary>
        /// The id of the contract
        /// </summary>
        public int ContractId { get; set; }
        
        /// <summary>
        /// The due date of the monthly payment
        /// </summary>
        public DateTime DueDate { get; set; }
        
        /// <summary>
        /// The amount due
        /// </summary>
        public decimal MonthlyPaymentAmountDue { get; set; }
        
        /// <summary>
        /// The date the monthly payment was paid in full
        /// </summary>
        public DateTime? PaymentCompletionDate { get; set; }
        
        /// <summary>
        /// The date the payment was skipped by an admin
        /// </summary>
        public DateTime? PaymentSkipedDate { get; set; }
        
        /// <summary>
        /// The user id of the admin who skipped the monthly payment
        /// </summary>
        public int? PaymentSkippedByUserId { get; set; }

        /// <summary>
        /// The contract dto
        /// </summary>
        public ContractDto Contract { get; set; } = new ContractDto();

        /// <summary>
        /// The user dto
        /// </summary>
        public UserDto PaymentSkippedByUser { get; set; } = new UserDto();

        /// <summary>
        /// The payments associated with the monthly payment
        /// </summary>
        public List<ContractPaymentDto> ContractPayments { get; set; } = new List<ContractPaymentDto>();

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
