using System.ComponentModel.DataAnnotations;

namespace MailChimpWrapper.Model.List
{
    /// <summary>
    /// Campaign object of mailchimp
    /// </summary>
    public class CampaignDefaultModel
    {
        /// <summary>
        /// The default from name for campaigns sent to this list.
        /// </summary>
        [Required(ErrorMessage = "From_name is required.")]
        public string from_name { get; set; }
        /// <summary>
        /// The default from email for campaigns sent to this list.
        /// </summary>
        [Required(ErrorMessage = "From_email is required.")]
        public string from_email { get; set; }
        /// <summary>
        /// The default subject line for campaigns sent to this list.
        /// </summary>
        [Required(ErrorMessage = "Subject is required.")]
        public string subject { get; set; }
        /// <summary>
        /// The default language for this lists’s forms.
        /// </summary>
        [Required(ErrorMessage = "Language is required.")]
        public string language { get; set; }
    }
}
