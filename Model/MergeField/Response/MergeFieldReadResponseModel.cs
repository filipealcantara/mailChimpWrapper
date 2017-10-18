using Newtonsoft.Json;

namespace MailChimpWrapper.Model.MergeField.Response
{
    /// <summary>
    /// Class that represents the response from merge field read
    /// </summary>
    public class MergeFieldReadResponseModel
    {
        /// <summary>
        /// An unchanging id for the merge field.
        /// </summary>
        public int merge_id { get; set; }
        /// <summary>
        /// The tag used in MailChimp campaigns and for the /members endpoint.
        /// </summary>        
        public string tag { get; set; }
        /// <summary>
        /// The name of the merge field.
        /// </summary>        
        public string name { get; set; }        
        /// <summary>
        /// The type for the merge field.
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// The boolean value if the merge field is required.
        /// </summary>        
        public bool required { get; set; }
        /// <summary>
        /// The default value for the merge field if null.
        /// </summary>        
        public string default_value { get; set; }
        /// <summary>
        /// Whether the merge field is displayed on the signup form.
        /// </summary>
        [JsonProperty(PropertyName = "public")]
        public bool Public { get; set; }
        /// <summary>
        /// The order that the merge field displays on the list signup form.
        /// </summary>        
        public int display_order { get; set; }
        /// <summary>
        /// Extra options for some merge field types.
        /// </summary>        
        public MergeFieldCreateOptionsModel options { get; set; }
        /// <summary>
        /// Extra text to help the subscriber fill out the form.
        /// </summary>        
        public string help_text { get; set; }
        /// <summary>
        /// A string that identifies this merge field collections’ list.
        /// </summary>
        public string list_id { get; set; }
        /// <summary>
        /// A list of link types and descriptions for the API schema documents.
        /// </summary>
        public LinksModel[] _links { get; set; }
    }
}
