namespace WebCRM.Data
{
    public interface IContractPayment
    {
        /// <summary>
        /// The id of the contract
        /// </summary>
        int ContractId { get; set; }

        /// <summary>
        /// The id of the contract monthly payment
        /// </summary>
        int? ContractMonthlyPaymentId { get; set; }

        /// <summary>
        /// The id of the user that entered the payment
        /// </summary>
        int EnteredByUserId { get; set; }

        /// <summary>
        /// The amount of the payment
        /// </summary>
        decimal PaymentAmount { get; set; }
    }
}