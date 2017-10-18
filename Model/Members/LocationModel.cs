using Newtonsoft.Json;

namespace MailChimpWrapper.Model.Members
{
    /// <summary>
    /// Class that represents the location json object on members
    /// </summary>
    public class LocationModel
    {
        /// <summary>
        /// The location latitude.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? latitude { get; set; }
        /// <summary>
        /// The location longitude.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? longitude { get; set; }
    }
}
