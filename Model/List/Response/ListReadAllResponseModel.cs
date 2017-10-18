namespace MailChimpWrapper.Model.List.Response
{
    /// <summary>
    /// Class that represents the response from mailchimp api to method readAll
    /// </summary>
    public class ListReadAllResponseModel
    {
        /// <summary>
        /// An array of objects, each representing a list.
        /// </summary>
        public ListReadResponseModel[] lists { get; set; }
        /// <summary>
        /// The total number of items matching the query regardless of pagination.
        /// </summary>
        public int total_items { get; set; }
    }
}
