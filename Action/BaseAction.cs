using RestSharp;
using RestSharp.Authenticators;

namespace MailChimpWrapper.Action
{
    /// <summary>
    /// Class that contains the default properties to connecting to mailchimp api
    /// </summary>
    public abstract class BaseAction
    {
        /// <summary>
        /// Base url to access the api
        /// </summary>
        private string baseUrl;
        /// <summary>
        /// Default user used to authenticate in api
        /// </summary>
        private const string defaultUser = "hariken";
        /// <summary>
        /// RestSharp Client 
        /// </summary>
        protected RestClient restClient;
        /// <summary>
        /// Version of the mailchimp api to be used
        /// </summary>
        protected string apiVersion = "3.0";

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <param name="apiKey">The api key from mailchimp</param>
        public BaseAction(string apiKey)
        {
            // Extract from the api the domain region of api
            var domainFromKey = apiKey.Split('-')[1];
            baseUrl = string.Format("https://{0}.api.mailchimp.com/{1}/", domainFromKey, apiVersion);

            // Initialize the rest client
            restClient = new RestClient(baseUrl);
            // Set the user and password to authenticate
            restClient.Authenticator = new HttpBasicAuthenticator(defaultUser, apiKey);            
        }
    }
}
