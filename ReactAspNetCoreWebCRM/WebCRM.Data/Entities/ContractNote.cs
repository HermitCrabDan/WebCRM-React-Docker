using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRM.Data
{
    /// <summary>
    /// The contract note entity
    /// </summary>
    public class ContractNote : BaseDataModel<ContractNote>, IContractNote
    {
        public ContractNote()
        {
            this.Contract = new Contract();
            this.User = new User();
            this.NoteText = string.Empty;
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
        /// The note text
        /// </summary>
        public string NoteText { get; set; }

        /// <summary>
        /// The id of the user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The user entity
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public override bool SecureUpdate(ContractNote model)
        {
            var propertiesChanged = this.ContractId != model.ContractId
                || this.UserId != model.UserId
                || this.NoteText != model.NoteText;

            if (propertiesChanged) 
            {
                this.ContractId = model.ContractId;
                this.UserId = model.UserId;
                this.NoteText = model.NoteText;
            }

            return propertiesChanged;
        }

        public override string ToString()
        {
            return $"ContractNote:{Id}=" +
                $"ContractId:{ContractId}," +
                $"UserId:{UserId}," +
                $"NoteText:{NoteText}";
        }
    }
}
