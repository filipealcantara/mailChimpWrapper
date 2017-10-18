namespace MailChimpWrapper.Model
{
    /// <summary>
    /// Class that encapsulates the link response object from mailchimp
    /// </summary>
    public class LinksModel
    {
        /// <summary>
        /// As with an HTML ‘rel’ attribute, this describes the type of link.
        /// </summary>
        public string rel { get; set; }
        /// <summary>
        /// This property contains a fully-qualified URL that can be called to retrieve the linked resource or perform the linked action.
        /// </summary>
        public string href { get; set; }
        /// <summary>
        /// The HTTP method that should be used when accessing the URL defined in ‘href’. Possible Values GET, POST, PUT, PATCH, DELETE, OPTIONS, HEAD.
        /// </summary>
        public string method { get; set; }
        /// <summary>
        /// For GETs, this is a URL representing the schema that the response should conform to.
        /// </summary>
        public string targetSchema { get; set; }
        /// <summary>
        /// For HTTP methods that can receive bodies (POST and PUT), this is a URL representing the schema that the body should conform to.
        /// </summary>
        public string schema { get; set; }
    }
}
