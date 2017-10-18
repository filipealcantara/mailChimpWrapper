using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MailChimpWrapper.Model.List
{
    /// <summary>
    /// Contact object to be send on mailchimp
    /// </summary>
    public class ContactModel
    {
        /// <summary>
        /// The company name for the list.
        /// </summary>
        [Required(ErrorMessage = "Company is required.")]
        public string company { get; set; }
        /// <summary>
        /// The street address for the list contact.
        /// </summary>
        [Required(ErrorMessage = "Address1 is required.")]
        public string address1 { get; set; }
        /// <summary>
        /// The street address for the list contact.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string address2 { get; set; }
        /// <summary>
        /// The city for the list contact.
        /// </summary>
        [Required(ErrorMessage = "City is required.")]
        public string city { get; set; }
        /// <summary>
        /// The state for the list contact.
        /// </summary>
        [Required(ErrorMessage = "State is required.")]
        public string state { get; set; }
        /// <summary>
        /// The postal or zip code for the list contact.
        /// </summary>
        [Required(ErrorMessage = "Zip is required.")]
        public string zip { get; set; }
        /// <summary>
        /// A two-character ISO3166 country code. Defaults to US if invalid.
        /// </summary>
        [Required(ErrorMessage = "Country is required.")]
        public string country { get; set; }
        /// <summary>
        /// The phone number for the list contact.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string phone { get; set; }
    }
}
