namespace MailChimpWrapper.Model.Members.Response
{
    /// <summary>
    /// Class that represents the response from read all members from a list.
    /// </summary>
    public class MembersReadAllResponseModel
    {
        /// <summary>
        /// An array of objects, each representing a specific list member.
        /// </summary>
        public MembersReadResponseModel[] members { get; set; }
        /// <summary>
        /// The list id.
        /// </summary>
        public string list_id { get; set; }
        /// <summary>
        /// The total number of items matching the query regardless of pagination.
        /// </summary>
        public int total_items { get; set; }
    }
}
