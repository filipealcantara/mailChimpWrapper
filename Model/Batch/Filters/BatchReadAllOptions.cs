namespace MailChimpWrapper.Model.Batch.Filters
{
    /// <summary>
    /// Options to filter a search for the batches
    /// </summary>
    public class BatchReadAllOptions : BatchReadOptions
    {
        /// <summary>
        /// The number of records to return.
        /// </summary>
        public int? count { get; set; }
        /// <summary>
        /// The number of records from a collection to skip. Iterating over large collections with this parameter can be slow.
        /// </summary>
        public int? offset { get; set; }
    }
}
