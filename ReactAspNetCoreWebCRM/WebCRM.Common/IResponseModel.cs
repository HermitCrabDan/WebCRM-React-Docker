namespace WebCRM.Common
{
    public interface IResponseModel<T> where T : class, new()
    {
        /// <summary>
        /// Whether or not there was anything to change
        /// </summary>
        bool DatabaseChanged { get; set; }

        /// <summary>
        /// A return message if needed
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// If there where changes, where they saved
        /// </summary>
        bool Success { get; set; }

        /// <summary>
        /// The object to return
        /// </summary>
        T Value { get; set; }
    }
}