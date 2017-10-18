using MailChimpWrapper.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MailChimpWrapper.Model.Members
{
    /// <summary>
    /// Model to update members with patch method on mailchimp API
    /// </summary>
    public class MembersPatchModel
    {
        /// <summary>
        /// Private field for email_type
        /// </summary>        
        private string _email_type;
        /// <summary>
        /// Type of email this member asked to get (‘html’ or ‘text’). Should be set with EmailTypes.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string email_type
        {
            get
            {
                return _email_type;
            }
            set
            {
                // Check if the value is a valid one from EmailTypes
                Type t = typeof(EmailTypes);
                var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);
                var result = fields.FirstOrDefault(x => x.GetValue(x).ToString().Equals(value));
                if (result == null)
                    throw new Exception(string.Format("Email Type {0} not supported.", value));
                _email_type = value;
            }
        }
        /// <summary>
        /// Private field for status
        /// </summary>
        private string _status;
        /// <summary>
        /// Subscriber’s current status. Should be set with StatusTypes.
        /// </summary>        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string status
        {
            get
            {
                return _status;
            }
            set
            {
                // Check if the value is a valid one from StatusTypes
                Type t = typeof(StatusTypes);
                var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);
                var result = fields.FirstOrDefault(x => x.GetValue(x).ToString().Equals(value));
                if (result == null)
                    throw new Exception(string.Format("Status Type {0} not supported.", value));
                _status = value;
            }
        }
        /// <summary>
        /// An individual merge var and value for a member.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> merge_fields;
        /// <summary>
        /// The key of this object’s properties is the ID of the interest in question.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, bool> interests;
        /// <summary>
        /// Private field for language property.
        /// </summary>        
        private string _language;
        /// <summary>
        /// If set/detected, the subscriber’s language.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string language
        {
            get
            {
                return _language;
            }
            set
            {
                // Check if the value is a valid one from StatusTypes
                Type t = typeof(LanguageTypes);
                var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);
                var result = fields.FirstOrDefault(x => x.GetValue(x).ToString().Equals(value));
                if (result == null)
                    throw new Exception(string.Format("Language Type {0} not supported.", value));
                _language = value;
            }
        }
        /// <summary>
        /// VIP status for subscriber.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? vip { get; set; }
        /// <summary>
        /// Subscriber location information.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public LocationModel location { get; set; }
        /// <summary>
        /// Email address for a subscriber.
        /// </summary>        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string email_address { get; set; }
    }
}
