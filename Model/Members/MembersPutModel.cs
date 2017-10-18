using MailChimpWrapper.Types;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;

namespace MailChimpWrapper.Model.Members
{
    /// <summary>
    /// Model to put (add/update) a user in mailchimp
    /// </summary>
    public class MembersPutModel : MembersCreateModel
    {
        private string _status_if_new;
        /// <summary>
        /// Subscriber’s status used only on a PUT request if the email is not already present on the list. Use StatusTypes to set
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string status_if_new
        {
            get
            {
                return _status_if_new;
            }
            set
            {
                // Check if the value is a valid one from StatusTypes
                Type t = typeof(StatusTypes);
                var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);
                var result = fields.FirstOrDefault(x => x.GetValue(x).ToString().Equals(value));
                if (result == null)
                    throw new Exception(string.Format("Status Type {0} not supported.", value));
                _status_if_new = value;
            }
        }
    }
}
