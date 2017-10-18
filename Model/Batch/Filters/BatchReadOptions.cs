using System.Collections.Generic;

namespace MailChimpWrapper.Model.Batch.Filters
{
    /// <summary>
    /// Options to filter a search for a batch
    /// </summary>
    public class BatchReadOptions
    {
        /// <summary>
        /// A list of fields to return.
        /// </summary>
        public List<string> fields { get; set; }
        /// <summary>
        /// A list of fields to exclude.
        /// </summary>
        public List<string> exclude_fields { get; set; }
    }
}
