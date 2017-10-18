namespace MailChimpWrapper.Model.MergeField.Response
{
    /// <summary>
    /// Class that represents the response from merge field read all
    /// </summary>
    public class MergeFieldReadAllResponseModel
    {
        /// <summary>
        /// An array of objects, each representing a merge field resource.
        /// </summary>
        public MergeFieldReadResponseModel[] merge_fields { get; set; }
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
