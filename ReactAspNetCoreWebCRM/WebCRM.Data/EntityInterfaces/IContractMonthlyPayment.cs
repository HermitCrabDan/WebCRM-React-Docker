namespace WebCRM.Data
{
    public interface IContractMonthlyPayment
    {
        /// <summary>
        /// The id of the contract
        /// </summary>
        int ContractId { get; set; }

        /// <summary>
        /// The date the payment is due
        /// </summary>
        DateTime DueDate { get; set; }

        /// <summary>
        /// The amount due for the monthly payment
        /// </summary>
        decimal MonthlyPaymentAmountDue { get; set; }

        /// <summary>
        /// The date that the payment was completed
        /// </summary>
        DateTime? PaymentCompletionDate { get; set; }

        /// <summary>
        /// The date the payment was skipped
        /// </summary>
        DateTime? PaymentSkipedDate { get; set; }

        /// <summary>
        /// The user that authorized the skipping of the payment
        /// </summary>
        int? PaymentSkippedByUserId { get; set; }
    }
}