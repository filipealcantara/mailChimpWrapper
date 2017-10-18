namespace MailChimpWrapper.Model
{
    /// <summary>
    /// Class that encapsulates the response from mail chimp api
    /// </summary>
    /// <typeparam name="T">Type of the response</typeparam>
    public class MailChimpWrapperResponse<T>
    {
        /// <summary>
        /// Object that contains the response from the executed action
        /// </summary>
        public T objectRespose { get; set; }
        /// <summary>
        /// Indicates when the call has errors
        /// </summary>
        public bool hasErrors { get; set; }

        /// <summary>
        /// Object that encapsulates the error from MailChimp Api
        /// </summary>
        public ErrorModel error { get; set; }
    }
}
