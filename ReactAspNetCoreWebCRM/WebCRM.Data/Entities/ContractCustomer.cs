using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRM.Data
{
    /// <summary>
    /// The contract customer entity
    /// </summary>
    public class ContractCustomer : SoftDeletedDataModel<ContractCustomer>, IContractCustomer
    {
        public ContractCustomer()
        {
            this.Contract = new Contract();
            this.Customer = new User();
        }

        /// <summary>
        /// The id of the contract
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// The contract entity
        /// </summary>
        [ForeignKey(nameof(ContractId))]
        public virtual Contract Contract { get; set; }

        /// <summary>
        /// The id of the user
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// The user entity
        /// </summary>
        [ForeignKey(nameof(CustomerId))]
        public virtual User Customer { get; set; }
    }
}
