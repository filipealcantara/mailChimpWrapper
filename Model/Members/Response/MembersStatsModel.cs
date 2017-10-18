namespace MailChimpWrapper.Model.Members.Response
{
    /// <summary>
    /// Class that represents open and click rates for subscribers.
    /// </summary>
    public class MembersStatsModel
    {
        /// <summary>
        /// A subscriber’s average open rate.
        /// </summary>
        public double avg_open_rate { get; set; }
        /// <summary>
        /// A subscriber’s average clickthrough rate.
        /// </summary>
        public double avg_click_rate { get; set; }
    }
}
