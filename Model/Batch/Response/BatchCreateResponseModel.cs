namespace MailChimpWrapper.Model.Batch.Response
{
    /// <summary>
    /// Model of the response object returned from create batch operation in mailchimp API
    /// </summary>
    public class BatchCreateResponseModel
    {
        /// <summary>
        /// A string that uniquely identifies this batch request.
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// The status of the batch call. Possible Values: pending, started, finished
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// The total number of operations to complete as part of this batch request. For GET requests requiring pagination, each page counts as a separate operation.
        /// </summary>
        public int total_operations { get; set; }
        /// <summary>
        /// The number of completed operations. This includes operations that returned an error.
        /// </summary>
        public int finished_operations { get; set; }
        /// <summary>
        /// The number of completed operations that returned an error.
        /// </summary>
        public int errored_operations { get; set; }
        /// <summary>
        /// The time and date when the server received the batch request.
        /// </summary>
        public string submitted_at { get; set; }
        /// <summary>
        /// The time and date when all operations in the batch request completed.
        /// </summary>
        public string completed_at { get; set; }
        /// <summary>
        /// The URL of the gzipped archive of the results of all the operations.
        /// </summary>
        public string response_body_url { get; set; }
    }
}
