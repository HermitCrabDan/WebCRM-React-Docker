namespace WebCRM.Data
{
    /// <summary>
    /// The user entity
    /// </summary>
    public class User : SoftDeletedDataModel<User>, IUser
    {
        public User()
        {
            this.Email = string.Empty;
            this.Name = string.Empty;
            this.UserRoles = new List<RoleMember>();
            this.ContractCustomers = new List<ContractCustomer>();
            this.ContractNotesCreatedByUser = new List<ContractNote>();
            this.ContractPaymentsEnteredByUser = new List<ContractPayment>();
            this.ContractMonthlyPaymentsSkippedByUser = new List<ContractMonthlyPayment>();
        }

        /// <summary>
        /// The user's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user's Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The user type
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// The Contract Customers associated with the user
        /// </summary>
        public virtual ICollection<ContractCustomer> ContractCustomers { get; set; }

        /// <summary>
        /// The application roles that the user is associated with
        /// </summary>
        public virtual ICollection<RoleMember> UserRoles { get; set; }

        /// <summary>
        /// The contract notes created by the user
        /// </summary>
        public virtual ICollection<ContractNote> ContractNotesCreatedByUser { get; set; }

        /// <summary>
        /// The contract payments entered by the user
        /// </summary>
        public virtual ICollection<ContractPayment> ContractPaymentsEnteredByUser { get; set; }

        /// <summary>
        /// The contract payments authorized to be skipped by the user
        /// </summary>
        public virtual ICollection<ContractMonthlyPayment> ContractMonthlyPaymentsSkippedByUser { get; set; }
    }
}
