namespace MailChimpWrapper.Model.List
{
    /// <summary>
    /// The stats from the list returned in mailchimp
    /// </summary>
    public class ListStatsModel
    {
        /// <summary>
        /// The number of active members in the list.
        /// </summary>
        public int member_count { get; set; }
        /// <summary>
        /// The number of members who have unsubscribed from the list.
        /// </summary>
        public int unsubscribe_count { get; set; }
        /// <summary>
        /// The number of members cleaned from the list.
        /// </summary>
        public int cleaned_count { get; set; }
        /// <summary>
        /// The number of active members in the list since the last campaign was sent.
        /// </summary>
        public int member_count_since_send { get; set; }
        /// <summary>
        /// The number of members who have unsubscribed since the last campaign was sent.
        /// </summary>
        public int unsubscribe_count_since_send { get; set; }
        /// <summary>
        /// The number of members cleaned from the list since the last campaign was sent.
        /// </summary>
        public int cleaned_count_since_send { get; set; }
        /// <summary>
        /// The number of campaigns in any status that use this list.
        /// </summary>
        public int campaign_count { get; set; }
        /// <summary>
        /// The date and time the last campaign was sent to this list.
        /// </summary>
        public string campaign_last_sent { get; set; }
        /// <summary>
        /// The number of merge vars for this list (not EMAIL, which is required).
        /// </summary>
        public int merge_field_count { get; set; }
        /// <summary>
        /// The average number of subscriptions per month for the list (not returned if we haven’t calculated it yet).
        /// </summary>
        public double avg_sub_rate { get; set; }
        /// <summary>
        /// The average number of unsubscriptions per month for the list (not returned if we haven’t calculated it yet).
        /// </summary>
        public double avg_unsub_rate { get; set; }
        /// <summary>
        /// The target number of subscriptions per month for the list to keep it growing (not returned if we haven’t calculated it yet).
        /// </summary>
        public double target_sub_rate { get; set; }
        /// <summary>
        /// The average open rate (a percentage represented as a number between 0 and 100) per campaign for the list (not returned if we haven’t calculated it yet).
        /// </summary>
        public double open_rate { get; set; }
        /// <summary>
        /// The average click rate (a percentage represented as a number between 0 and 100) per campaign for the list (not returned if we haven’t calculated it yet).
        /// </summary>
        public double click_rate { get; set; }
        /// <summary>
        /// The date and time of the last time someone subscribed to this list.
        /// </summary>
        public string last_sub_date { get; set; }
        /// <summary>
        /// The date and time of the last time someone unsubscribed from this list.
        /// </summary>
        public string last_unsub_date { get; set; }
    }
}
