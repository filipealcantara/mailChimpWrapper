using MailChimpWrapper.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MailChimpWrapper.Model.Batch
{
    /// <summary>
    /// Class the represents the operation to be executed on batch
    /// </summary>
    public class OperationModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public OperationModel()
        {
        }
        /// <summary>
        /// Public constructor with the required fields as parameters
        /// </summary>
        /// <param name="method">The HTTP method to use for the operation. Use MethodTypes to set.</param>
        /// <param name="path">The relative path to use for the operation. Use ResourcesEndpoints to set.</param>
        public OperationModel(string method, string path)
        {
            this.method = method;
            this.path = path;
        }
        /// <summary>
        /// Private field for method.
        /// </summary>
        private string _method;
        /// <summary>
        /// The HTTP method to use for the operation. Use MethodTypes to set.
        /// </summary>
        [Required(ErrorMessage = "Field method is required")]
        public string method
        {
            get { return _method; }
            set
            {
                // Check if the value is a valid one from MethodTypes
                Type t = typeof(MethodTypes);
                var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);
                var result = fields.FirstOrDefault(x => x.GetValue(x).ToString().Equals(value));
                if (result == null)
                    throw new Exception(string.Format("Email Type {0} not supported.", value));
                _method = value;
            }
        }
        /// <summary>
        /// The relative path to use for the operation. Use ResourcesEndpoints to set.
        /// </summary>
        [Required(ErrorMessage = "Field path is required")]
        public string path { get; set; }
        /// <summary>
        /// Any URL params to use, only applies to GET operations.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> @params { get; set; }
        /// <summary>
        /// Private field for body object.
        /// </summary>
        private string _body { get; set; }
        /// <summary>
        /// A string containing the JSON body to use with the request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object body
        {
            get { return _body; }
            set
            {
                _body = JsonConvert.SerializeObject(value);
            }
        }
        /// <summary>
        /// An optional client-supplied id returned with the operation results.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string operation_id { get; set; }
    }
}
