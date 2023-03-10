namespace WebCRM.Data
{
    public interface IContract
    {
        /// <summary>
        /// The amount of the contract
        /// </summary>
        decimal ContractAmount { get; set; }

        /// <summary>
        /// The date the contracte ended
        /// </summary>
        DateTime? EndDate { get; set; }

        /// <summary>
        /// The payment day of the month
        /// </summary>
        int PaymentDayOfTheMonth { get; set; }

        /// <summary>
        /// The regular payment amount
        /// </summary>
        decimal RegularPaymentAmount { get; set; }

        /// <summary>
        /// The date the contract should start
        /// </summary>
        DateTime StartDate { get; set; }
    }
}