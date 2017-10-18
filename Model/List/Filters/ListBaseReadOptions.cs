using System.Collections.Generic;

namespace MailChimpWrapper.Model.List.Filters
{
    /// <summary>
    /// Base class that contains the common filter options for read operations in list actions.
    /// </summary>
    public abstract class ListBaseReadOptions
    {
        /// <summary>
        /// List of fields to return, if not set will return all fields
        /// </summary>
        public List<string> fields = new List<string>();
        /// <summary>
        /// List of fields to exclude from the response.
        /// </summary>
        public List<string> exclude_fields = new List<string>();
    }
}
