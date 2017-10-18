using System.ComponentModel.DataAnnotations;
using System;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;
using MailChimpWrapper.Types;
using MailChimpWrapper.Helpers;

namespace MailChimpWrapper.Model.List
{
    /// <summary>
    /// Class that represents the model of list to be created on mailchimp
    /// </summary>
    public class ListCreateModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ListCreateModel() { }
        /// <summary>
        /// Public constructor with the required fields as parameters
        /// </summary>
        /// <param name="name">The name of the list.</param>
        /// <param name="contact">Contact information displayed in campaign footers to comply with international spam laws.</param>
        /// <param name="permission_reminder">The permission reminder for the list.</param>
        /// <param name="campaign_defaults">Default values for campaigns created for this list.</param>
        /// <param name="email_type_option">Whether the list supports multiple formats for emails. When set to true, subscribers can choose whether they want to receive HTML or plain-text emails.
        /// When set to false, subscribers will receive HTML emails, with a plain-text alternative backup.</param>
        public ListCreateModel(
            string name, ContactModel contact,
            string permission_reminder, CampaignDefaultModel campaign_defaults,
            bool email_type_option)
        {
            this.name = name;
            this.contact = contact;
            this.permission_reminder = permission_reminder;
            this.campaign_defaults = campaign_defaults;
            this.email_type_option = email_type_option;
        }
        /// <summary>
        /// The name of the list.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        /// <summary>
        /// Contact information displayed in campaign footers to comply with international spam laws.
        /// </summary>
        [Required(ErrorMessage = "Contact is required."), ValidateObject]
        public ContactModel contact { get; set; }
        /// <summary>
        /// The permission reminder for the list.
        /// </summary>
        [Required(ErrorMessage = "Permission_reminder is required.")]
        public string permission_reminder { get; set; }
        /// <summary>
        /// Whether campaigns for this list use the Archive Bar in archives by default.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? use_archive_bar { get; set; }
        /// <summary>
        /// Default values for campaigns created for this list.
        /// </summary>
        [Required(ErrorMessage = "Campaign_defaults is required."), ValidateObject]
        public CampaignDefaultModel campaign_defaults { get; set; }
        /// <summary>
        /// The email address to send subscribe notifications to.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string notify_on_subscribe { get; set; }
        /// <summary>
        /// The email address to send unsubscribe notifications to.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string notify_on_unsubscribe { get; set; }
        /// <summary>
        /// Whether the list supports multiple formats for emails. When set to true, subscribers can choose whether they want to receive HTML or plain-text emails.
        /// When set to false, subscribers will receive HTML emails, with a plain-text alternative backup.
        /// </summary>
        [Required(ErrorMessage = "Email_type_option is required.")]
        public bool email_type_option { get; set; }
        /// <summary>
        /// Private field for visibility property
        /// </summary>
        private string _visibility;
        /// <summary>
        /// Whether this list is public or private. Possible Values: pub , prv        
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                // Check if the value is a valid one from VisibilityTypes
                Type t = typeof(VisibilityTypes);
                var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);
                var result = fields.FirstOrDefault(x => x.GetValue(x).ToString().Equals(value));
                if (result == null)
                    throw new Exception(string.Format("Visibility {0} not supported.", value));
                _visibility = value;
            }
        }
    }
}
