using MailChimpWrapper.Model;
using System;

namespace MailChimpWrapper.Action
{
    /// <summary>
    /// Class to hold the common methods used by all actions classes
    /// </summary>
    internal static class Common
    {
        /// <summary>
        /// Fill the MailChimpWrapperResponse with the given exception to return
        /// </summary>
        /// <typeparam name="T">Type of MailChimpWrapperResponse</typeparam>
        /// <param name="ex">Exception that happened</param>
        /// <returns></returns>
        public static MailChimpWrapperResponse<T> ErrorResponse<T>(Exception ex)
        {
            var errorContent = new ErrorModel
            {
                type = "Internal Method Error.",
                title = ex.Message,
                status = 0,
                detail = ex.StackTrace
            };
            return new MailChimpWrapperResponse<T>
            {
                hasErrors = true,
                error = errorContent
            };
        }
    }
}
