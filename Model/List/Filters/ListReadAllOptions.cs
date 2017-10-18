namespace MailChimpWrapper.Model.List.Filters
{
    /// <summary>
    /// Class that contains the options parameters to filter the readAll response from mailchimp
    /// </summary>
    public class ListReadAllOptions : ListBaseReadOptions
    {        
        /// <summary>
        /// The number of records to return.
        /// </summary>
        public int? count;
        /// <summary>
        /// The number of records from a collection to skip. Iterating over large collections with this parameter can be slow.
        /// </summary>
        public int? offset;
        /// <summary>
        /// Restrict response to lists created before the set date.
        /// </summary>
        public string before_date_created;
        /// <summary>
        /// Restrict results to lists created after the set date.
        /// </summary>
        public string since_date_created;
        /// <summary>
        /// Restrict results to lists created before the last campaign send date.
        /// </summary>
        public string before_campaign_last_sent;
        /// <summary>
        /// Restrict results to lists created after the last campaign send date.
        /// </summary>
        public string since_campaign_last_sent;

    }
}
