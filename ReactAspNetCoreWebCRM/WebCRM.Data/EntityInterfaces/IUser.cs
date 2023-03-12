namespace WebCRM.Data
{
    public interface IUser
    {
        /// <summary>
        /// The user's email
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// The user's name
        /// </summary>
        string Name { get; set; }
    }
}