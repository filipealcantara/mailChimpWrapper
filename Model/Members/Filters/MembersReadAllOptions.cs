using MailChimpWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MailChimpWrapper.Model.Members.Filters
{
    /// <summary>
    /// Options to query in members read all endpoint
    /// </summary>
    public class MembersReadAllOptions
    {
        /// <summary>
        /// A list of fields to return.
        /// </summary>
        public List<string> fields { get; set; }
        /// <summary>
        /// A list of fields to exclude.
        /// </summary>
        public List<string> exclude_fields { get; set; }
        /// <summary>
        /// The number of records to return.
        /// </summary>
        public int? count { get; set; }
        /// <summary>
        /// The number of records from a collection to skip. Iterating over large collections with this parameter can be slow.
        /// </summary>
        public int? offset { get; set; }
        /// <summary>
        /// Private field for email_type
        /// </summary>        
        private string _email_type;
        /// <summary>
        /// Type of email this member asked to get (‘html’ or ‘text’). Should be set with EmailTypes.
        /// </summary>        
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
        /// Restrict results to subscribers who opted-in after the set timeframe.
        /// </summary>
        public string since_timestamp_opt { get; set; }
        /// <summary>
        /// Restrict results to subscribers who opted-in before the set timeframe.
        /// </summary>
        public string before_timestamp_opt { get; set; }
        /// <summary>
        /// Restrict results to subscribers whose information changed after the set timeframe.
        /// </summary>
        public string since_last_changed { get; set; }
        /// <summary>
        /// Restrict results to subscribers whose information changed before the set timeframe.
        /// </summary>
        public string before_last_changed { get; set; }
    }
}
