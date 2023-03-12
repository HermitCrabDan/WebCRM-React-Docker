using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRM.Common
{
    /// <summary>
    /// The model representing the repository response
    /// </summary>
    /// <typeparam name="T">The data class to be returned</typeparam>
    public class ResponseModel<T> : IResponseModel<T> where T : class, new()
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ResponseModel()
        {
            this.Success = false;
            this.DatabaseChanged = false;
            this.Message = string.Empty;
            this.Value = new T();
        }

        /// <summary>
        /// Complete constructor
        /// </summary>
        /// <param name="success">bool indicating successful save</param>
        /// <param name="databaseChanged">bool indicating if there where changes</param>
        /// <param name="message">return message</param>
        /// <param name="value">return value</param>
        public ResponseModel(
            bool success = false, 
            bool databaseChanged = false, 
            string message = "", 
            T? value = null)
        {
            this.Success = success;
            this.DatabaseChanged = databaseChanged;
            this.Message = message;
            this.Value = value ?? new T();
        }

        /// <summary>
        /// If there where changes, where they saved
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Whether or not there was anything to change
        /// </summary>
        public bool DatabaseChanged { get; set; }

        /// <summary>
        /// A return message if needed
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The object to return
        /// </summary>
        public T Value { get; set; }
    }

    public static class ResponseModelExtensions
    {
        public static IResponseModel<T> ToResponseModel<T, U>(this IResponseModel<U> responseModel, T model)
            where T : class, new()
            where U : class, new()
        {
            if (responseModel == null)
            {
                return new ResponseModel<T>(false, false, CRMConstants.NullDataSent, new T());
            }

            return new ResponseModel<T>
            {
                DatabaseChanged = responseModel.DatabaseChanged,
                Message = responseModel.Message,
                Success = responseModel.Success,
                Value = model
            };
        }
    }
}
