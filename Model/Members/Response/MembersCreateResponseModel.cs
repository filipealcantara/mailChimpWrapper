namespace MailChimpWrapper.Model.Members.Response
{
    /// <summary>
    /// Class that represents the response from mailchimp API to create members action
    /// </summary>
    public class MembersCreateResponseModel : MembersCreateModel
    {
        /// <summary>
        /// The MD5 hash of the lowercase version of the list member’s email address.
        /// </summary>
        public string id { get; set; }        
        /// <summary>
        /// An identifier for the address across all of MailChimp.
        /// </summary>
        public string unique_email_id { get; set; }
        /// <summary>
        /// Open and click rates for this subscriber.
        /// </summary>
        public MembersStatsModel stats { get; set; }
        /// <summary>
        /// IP address the subscriber signed up from.
        /// </summary>
        public string ip_signup { get; set; }
        /// <summary>
        /// Date and time the subscriber signed up for the list.
        /// </summary>
        public string timestamp_signup { get; set; }
        /// <summary>
        /// The IP address the subscriber used to confirm their opt-in status.
        /// </summary>
        public string ip_opt { get; set; }
        /// <summary>
        /// Date and time the subscribe confirmed their opt-in status.
        /// </summary>
        public string timestamp_opt { get; set; }
        /// <summary>
        /// Star rating for this member, between 1 and 5.
        /// </summary>
        public int member_rating { get; set; }
        /// <summary>
        /// Date and time the member’s info was last changed.
        /// </summary>
        public string last_changed { get; set; }        
        /// <summary>
        /// The list member’s email client.
        /// </summary>
        public string email_client { get; set; }
        /// <summary>
        /// The most recent Note added about this member.
        /// </summary>
        public MembersNoteModel last_note { get; set; }
        /// <summary>
        /// The list id.
        /// </summary>
        public string list_id { get; set; }
        /// <summary>
        /// A list of link types and descriptions for the API schema documents.
        /// </summary>
        public LinksModel[] _links { get; set; }
    }
}
