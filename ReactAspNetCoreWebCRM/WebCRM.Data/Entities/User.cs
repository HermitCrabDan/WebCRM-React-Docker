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
            this.Password = string.Empty;
            this.UserName = string.Empty;
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
        /// The User's login
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The User's Password
        /// </summary>
        public string Password { get; set; }

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

        public override bool SecureUpdate(User model)
        {
            var propertiesChanged = false;

            this.Name = model.Name;
            this.Email = model.Email;

            return propertiesChanged;
        }

        /// <summary>
        /// Updates the user's password
        /// </summary>
        /// <param name="newPassword">The new Password</param>
        /// <returns>true if the new password is different from the current, false otherwise</returns>
        public bool SetPassword(string newPassword)
        {
            var passwordChanged = this.Password != newPassword;
            if (passwordChanged)
            {
                this.Password = newPassword;
            }
            return passwordChanged;
        }

        /// <summary>
        /// Updates the user's login
        /// </summary>
        /// <param name="newUserName">The new UserName</param>
        /// <returns>true if the new UserName is different from the current, false otherwise</returns>
        public bool SetUserName(string newUserName)
        {
            var userNameChanged = this.UserName != newUserName;
            if (userNameChanged) 
            {
                this.UserName = newUserName;
            }
            return userNameChanged;
        }

        public override string ToString()
        {
            return $"User:{Id}=" +
                $"Name:{Name}," +
                $"Email{Email}";
        }
    }
}
