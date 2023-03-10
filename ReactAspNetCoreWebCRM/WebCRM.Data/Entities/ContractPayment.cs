using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRM.Data
{
    /// <summary>
    /// The contract payment entity
    /// </summary>
    public class ContractPayment : SoftDeletedDataModel<ContractPayment>, IContractPayment
    {
        public ContractPayment()
        {
            this.Contract = new Contract();
            this.EnteredByUser = new User();
            this.ContractMonthlyPayment = new ContractMonthlyPayment();
        }

        /// <summary>
        /// The amount of the payment
        /// </summary>
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// The id of the contract customer
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// The contract customer entity
        /// </summary>
        [ForeignKey(nameof(ContractId))]
        public virtual Contract Contract { get; set; }

        /// <summary>
        /// The id of the logged in user
        /// </summary>
        public int EnteredByUserId { get; set; }

        /// <summary>
        /// The user entity who entered the payment
        /// </summary>
        [ForeignKey(nameof(EnteredByUserId))]
        public virtual User EnteredByUser { get; set; }

        /// <summary>
        /// The id of the monthly payment associated with the payment
        /// </summary>
        public int? ContractMonthlyPaymentId { get; set; }

        /// <summary>
        /// The monthly payment entity associated with the payment
        /// </summary>
        [ForeignKey(nameof(ContractMonthlyPaymentId))]
        public virtual ContractMonthlyPayment ContractMonthlyPayment { get; set; }
    }
}
