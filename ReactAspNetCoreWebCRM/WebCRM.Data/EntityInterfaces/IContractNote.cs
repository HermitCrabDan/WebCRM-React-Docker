namespace WebCRM.Data
{
    public interface IContractNote
    {
        /// <summary>
        /// The id of the contract
        /// </summary>
        int ContractId { get; set; }

        /// <summary>
        /// The note text
        /// </summary>
        string NoteText { get; set; }

        /// <summary>
        /// The id of the user
        /// </summary>
        int UserId { get; set; }
    }
}