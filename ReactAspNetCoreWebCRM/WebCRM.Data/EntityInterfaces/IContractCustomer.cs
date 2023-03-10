namespace WebCRM.Data
{
    public interface IContractCustomer
    {
        /// <summary>
        /// The id of the contract
        /// </summary>
        int ContractId { get; set; }

        /// <summary>
        /// The user id of the customer
        /// </summary>
        int CustomerId { get; set; }
    }
}