using MailChimpWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MailChimpWrapper.Model.MergeField.Filters
{
    /// <summary>
    /// Base class that contains the common filter options for read operations in merge field actions.
    /// </summary>
    public class MergeFieldReadAllOptions
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
        /// Private field for type property
        /// </summary>
        private string _type;
        /// <summary>
        /// The merge field type. Use MergeFieldTypes class to set.
        /// </summary>
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
        public bool? required { get; set; }
    }
}
