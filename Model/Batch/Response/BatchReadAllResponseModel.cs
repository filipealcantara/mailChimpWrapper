namespace MailChimpWrapper.Model.Batch.Response
{
    /// <summary>
    /// Model that represent the response from batch read all endpoint
    /// </summary>
    public class BatchReadAllResponseModel
    {
        /// <summary>
        /// An array of objects representing batch calls.
        /// </summary>
        public BatchReadResponseModel[] batches { get; set; }
        /// <summary>
        /// The total number of items matching the query regardless of pagination.
        /// </summary>
        public int total_items { get; set; }
    }
}
