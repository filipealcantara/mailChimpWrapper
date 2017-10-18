using System.ComponentModel.DataAnnotations;

namespace MailChimpWrapper.Model.List.Response
{
    /// <summary>
    /// Class that encapsulates the response from Read operation in mailchimp API
    /// </summary>
    public class ListReadResponseModel
    {
        /// <summary>
        /// A string that uniquely identifies this list.
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// The name of the list.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        /// <summary>
        /// Contact information displayed in campaign footers to comply with international spam laws.
        /// </summary>
        [Required(ErrorMessage = "Contact is required.")]
        public ContactModel contact { get; set; }
        /// <summary>
        /// The permission reminder for the list.
        /// </summary>
        [Required(ErrorMessage = "Permission_reminder is required.")]
        public string permission_reminder { get; set; }
        /// <summary>
        /// Whether campaigns for this list use the Archive Bar in archives by default.
        /// </summary>
        public bool use_archive_bar { get; set; }
        /// <summary>
        /// Default values for campaigns created for this list.
        /// </summary>
        [Required(ErrorMessage = "Campaign_defaults is required.")]
        public CampaignDefaultModel campaign_defaults { get; set; }
        /// <summary>
        /// The email address to send subscribe notifications to.
        /// </summary>
        public string notify_on_subscribe { get; set; }
        /// <summary>
        /// The email address to send unsubscribe notifications to.
        /// </summary>
        public string notify_on_unsubscribe { get; set; }
        /// <summary>
        /// Whether the list supports multiple formats for emails. When set to true, subscribers can choose whether they want to receive HTML or plain-text emails.
        /// When set to false, subscribers will receive HTML emails, with a plain-text alternative backup.
        /// </summary>
        [Required(ErrorMessage = "Email_type_option is required.")]
        public bool email_type_option { get; set; }
        /// <summary>
        /// Our EepURL shortened version of this list’s subscribe form.
        /// </summary>
        public string subscribe_url_short { get; set; }
        /// <summary>
        /// The full version of this list’s subscribe form (host will vary).
        /// </summary>
        public string subscribe_url_long { get; set; }
        /// <summary>
        /// The list’s Email Beamer address.
        /// </summary>
        public string beamer_address { get; set; }
        /// <summary>
        /// Whether this list is public or private. Possible Values: pub , prv        
        /// </summary>
        public string visibility { get; set; }
        /// <summary>
        /// Any list-specific modules installed for this list.
        /// </summary>
        public object modules { get; set; }
        /// <summary>
        /// Stats for the list. Many of these are cached for at least five minutes.
        /// </summary>
        public ListStatsModel stats { get; set; }
        /// <summary>
        /// A list of link types and descriptions for the API schema documents.
        /// </summary>
        public LinksModel[] _links { get; set; }
    }
}
