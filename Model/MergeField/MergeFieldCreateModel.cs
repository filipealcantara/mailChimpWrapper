using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;
using MailChimpWrapper.Types;

namespace MailChimpWrapper.Model.MergeField
{
    /// <summary>
    /// Class that represents the model of a merge field to be created on a list in mailchimp
    /// </summary>
    public class MergeFieldCreateModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MergeFieldCreateModel() { }
        /// <summary>
        /// Public constructor with the required fields as parameters
        /// </summary>
        /// <param name="name">The name of the merge field.</param>
        /// <param name="tag">The tag of the merge field. Maximum of 10 characters.</param>
        /// <param name="type">The type for the merge field. Use MergeFieldTypes class to set.</param>
        public MergeFieldCreateModel(string name, string tag, string type) {
            this.name = name;
            this.type = type;
            this.tag = tag;
        }
        /// <summary>
        /// Private field for tag property
        /// </summary>
        private string _tag;
        /// <summary>
        /// The tag used in MailChimp campaigns and for the /members endpoint.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string tag
        {
            get
            {
                return _tag;
            }
            set
            {
                if (value.Length > 10)
                    throw new Exception(string.Format("Tag {0} contains more then 10 characters.", value));
                _tag = value;
            }
        }
        /// <summary>
        /// The name of the merge field.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        /// <summary>
        /// Private field for type property
        /// </summary>
        private string _type;
        /// <summary>
        /// The type for the merge field. Use MergeFieldTypes class to set.
        /// </summary>
        [Required(ErrorMessage = "Type is required.")]
        public string type
        {
            get
            {
                return _type;
            }
            set
            {
                // Check if the value is a valid one from MergeFieldTypes
                Type t = typeof(MergeFieldTypes);
                var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);
                var result = fields.FirstOrDefault(x => x.GetValue(x).ToString().Equals(value));
                if (result == null)
                    throw new Exception(string.Format("Type {0} not supported.", value));
                _type = value;
            }
        }
        /// <summary>
        /// The boolean value if the merge field is required.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? required { get; set; }
        /// <summary>
        /// The default value for the merge field if null.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string default_value { get; set; }        
        /// <summary>
        /// Whether the merge field is displayed on the signup form.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "public")]
        public bool? Public{ get; set; }
        /// <summary>
        /// The order that the merge field displays on the list signup form.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? display_order { get; set; }
        /// <summary>
        /// Extra options for some merge field types.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MergeFieldCreateOptionsModel options { get; set; }
        /// <summary>
        /// Extra text to help the subscriber fill out the form.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string help_text { get; set; }
    }
}
