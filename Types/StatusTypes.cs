namespace MailChimpWrapper.Types
{
    /// <summary>
    /// Represents the types of possible status for members. eg: member status = subscribed
    /// </summary>
    public static class StatusTypes
    {
        /// <summary>
        /// Gets the string representation of subscribed member for mailchimp
        /// </summary>
        public static readonly string subscribed = "subscribed";
        /// <summary>
        /// Gets the string representation of unsubscribed member for mailchimp
        /// </summary>
        public static readonly string unsubscribed = "unsubscribed";
        /// <summary>
        /// Gets the string representation of cleaned member for mailchimp
        /// </summary>
        public static readonly string cleaned = "cleaned";
        /// <summary>
        /// Gets the string representation of pending member for mailchimp
        /// </summary>
        public static readonly string pending = "pending";
    }
}
