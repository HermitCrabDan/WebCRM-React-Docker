using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRM.Data
{
    /// <summary>
    /// The contract monthly payment entity
    /// </summary>
    public class ContractMonthlyPayment : SoftDeletedDataModel<ContractMonthlyPayment>, IContractMonthlyPayment
    {
        public ContractMonthlyPayment()
        {
            this.Contract = new Contract();
            this.ContractPayments = new List<ContractPayment>();
            this.PaymentSkippedByUser = new User();
        }

        /// <summary>
        /// The date the payment is due
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// The id of the contract
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// The contract entity
        /// </summary>
        [ForeignKey(nameof(ContractId))]
        public Contract Contract { get; set; }

        /// <summary>
        /// The amount due for the monthly payment
        /// </summary>
        public decimal MonthlyPaymentAmountDue { get; set; }

        /// <summary>
        /// The date that the payment was completed
        /// </summary>
        public DateTime? PaymentCompletionDate { get; set; }

        /// <summary>
        /// The date the payment was skipped
        /// </summary>
        public DateTime? PaymentSkipedDate { get; set; }

        /// <summary>
        /// The user that authorized the skipping of the payment
        /// </summary>
        public int? PaymentSkippedByUserId { get; set; }

        /// <summary>
        /// The user entity that skipped the payment
        /// </summary>
        [ForeignKey(nameof(PaymentSkippedByUserId))]
        public virtual User PaymentSkippedByUser { get; set; }

        /// <summary>
        /// The payments associated with the monthly payment
        /// </summary>
        public virtual ICollection<ContractPayment> ContractPayments { get; set; }

        public override bool SecureUpdate(ContractMonthlyPayment model)
        {
            var propertiesChanged = this.ContractId != model.ContractId
                || this.DueDate != model.DueDate
                || this.MonthlyPaymentAmountDue != model.MonthlyPaymentAmountDue
                || this.PaymentCompletionDate != model.PaymentCompletionDate
                || this.PaymentSkipedDate != model.PaymentSkipedDate
                || this.PaymentSkippedByUserId != model.PaymentSkippedByUserId;

            if (propertiesChanged) 
            {
                this.ContractId = model.ContractId;
                this.DueDate = model.DueDate;
                this.MonthlyPaymentAmountDue = model.MonthlyPaymentAmountDue;
                this.PaymentCompletionDate = model.PaymentCompletionDate;
                this.PaymentSkipedDate = model.PaymentSkipedDate;
                this.PaymentSkippedByUserId = model.PaymentSkippedByUserId;
            }

            return propertiesChanged;
        }

        public override string ToString()
        {
            return $"ContractMonthlyPayment:{Id}=" +
                $"ContractId:{ContractId}," +
                $"DueDate:{DueDate}," +
                $"MonthlyPaymentAmountDue:{MonthlyPaymentAmountDue}," +
                $"PaymentCompletionDate:{PaymentCompletionDate}," +
                $"PaymentSkipedDate:{PaymentSkipedDate}," +
                $"PaymentSkippedByUserId:{PaymentSkippedByUserId}";
        }
    }
}
