namespace MailChimpWrapper.Model
{
    /// <summary>
    /// Error Details to complete the error object returned when an error occurs in mailchimp api
    /// </summary>
    public class ErrorDetailModel
    {
        /// <summary>
        /// Name of the field that suffers the error
        /// </summary>
        public string field { get; set; }
        /// <summary>
        /// readable message of the error
        /// </summary>
        public string message { get; set; }
    }
}
