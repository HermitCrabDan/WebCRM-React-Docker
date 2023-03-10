using System;
using System.ComponentModel;

namespace WebCRM.Data
{
    /// <summary>
    /// The contract entity
    /// </summary>
    public class Contract : SoftDeletedDataModel<Contract>, IContract
    {
        public Contract()
        {
            this.ContractCustomers = new List<ContractCustomer>();
            this.ContractNotes = new List<ContractNote>();
            this.ContractPayments = new List<ContractPayment>();
            this.ContractMonthlyPayments = new List<ContractMonthlyPayment>();
        }

        /// <summary>
        /// The start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The regular payment date
        /// </summary>
        public int PaymentDayOfTheMonth { get; set; }

        /// <summary>
        /// The amount of the regular payments
        /// </summary>
        public decimal RegularPaymentAmount { get; set; }

        /// <summary>
        /// The amount of the contract
        /// </summary>
        public decimal ContractAmount { get; set; }

        /// <summary>
        /// The customers associated with the contract
        /// </summary>
        public virtual ICollection<ContractCustomer> ContractCustomers { get; set; }

        /// <summary>
        /// The notes associated with the contract
        /// </summary>
        public virtual ICollection<ContractNote> ContractNotes { get; set; }

        /// <summary>
        /// The payments associated with the contract
        /// </summary>
        public virtual ICollection<ContractPayment> ContractPayments { get; set; }

        /// <summary>
        /// The monthly payments for the contract
        /// </summary>
        public virtual ICollection<ContractMonthlyPayment> ContractMonthlyPayments { get; set; }
    }
}
