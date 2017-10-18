using MailChimpWrapper.Helpers;

namespace MailChimpWrapper.Endpoints
{
    /// <summary>
    /// Static Class that contains the strings of all resources endpoints of Mailchimp API
    /// </summary>
    public static class ResourcesEndpoints
    {
        #region List
        /// <summary>
        /// The resource endpoint for creating a list
        /// </summary>
        public static string ListCreate() {
            return "lists";
        }
        /// <summary>
        /// The resource endpoint for reading all lists
        /// </summary>
        public static string ListReadAll()
        {
            return "lists";
        }
        /// <summary>
        /// The resource endpoint for reading a list by id
        /// <param name="listId">The Id of the list</param>
        /// </summary>
        public static string ListRead(string listId) {            
            return string.Format("lists/{0}", listId);
        }
        /// <summary>
        /// The resource endpoint for update a list by id
        /// <param name="listId">The Id of the list</param>
        /// </summary>        
        public static string ListEdit(string listId)
        {
            return string.Format("lists/{0}", listId);
        }
        /// <summary>
        /// The resource endpoint for deleting a list by id
        /// <param name="listId">The Id of the list</param>
        /// </summary>        
        public static string ListDelete(string listId)
        {
            return string.Format("lists/{0}", listId);
        }
        #endregion

        #region Merge Field
        /// <summary>
        /// The resource endpoint for creating a merge field by list id
        /// <param name="listId">The Id of the list</param>
        /// </summary>
        public static string MergeFieldCreate(string listId)
        {
            return string.Format("lists/{0}/merge-fields", listId);
        }
        /// <summary>
        /// The resource endpoint for reading all merge fields from a list
        /// <param name="listId">The Id of the list</param>
        /// </summary>
        public static string MergeFieldReadAll(string listId)
        {
            return string.Format("lists/{0}/merge-fields", listId);
        }
        /// <summary>
        /// The resource endpoint for reading a merge field from a list
        /// <param name="listId">List Id</param>
        /// <param name="mergeFieldId">Merge-field id</param>
        /// </summary>        
        public static string MergeFieldRead(string listId, int mergeFieldId)
        {
            return string.Format("lists/{0}/merge-fields/{1}", listId, mergeFieldId);
        }
        /// <summary>
        /// The resource endpoint for update a merge field from a list
        /// <param name="listId">List Id</param>
        /// <param name="mergeFieldId">Merge-field id</param>
        /// </summary>        
        public static string MergeFieldEdit(string listId, int mergeFieldId)
        {
            return string.Format("lists/{0}/merge-fields/{1}", listId, mergeFieldId);
        }
        /// <summary>
        /// The resource endpoint to delete a merge field from a list
        /// <param name="listId">List Id</param>
        /// <param name="mergeFieldId">Merge-field id</param>
        /// </summary>
        public static string MergeFieldDelete(string listId, int mergeFieldId)
        {
            return string.Format("lists/{0}/merge-fields/{1}", listId, mergeFieldId);
        }
        #endregion

        #region Members
        /// <summary>
        /// The resource endpoint for creating a member in a list
        /// <param name="listId">List Id</param>
        /// </summary>
        public static string MembersCreate(string listId)
        {
            return string.Format("lists/{0}/members", listId);
        }
        /// <summary>
        /// The resource endpoint for reading all members in a list
        /// <param name="listId">List Id</param>
        /// </summary>        
        public static string MembersReadAll(string listId)
        {
            return string.Format("lists/{0}/members", listId);
        }
        /// <summary>
        /// The resource endpoint for reading a members from a list
        /// <param name="listId">List Id</param>
        /// <param name="email_address">Email Addres of the member</param>        
        /// </summary>        
        public static string MembersRead(string listId, string email_address)
        {
            return string.Format("lists/{0}/members/{1}", listId, Util.CalculateSubscriberHash(email_address));
        }
        /// <summary>
        /// The resource endpoint for updating a member from a list, (can but used with patch or put)
        /// <param name="listId">List Id</param>
        /// <param name="email_address">Email Addres of the member</param>        
        /// </summary>        
        public static string MembersUpdate(string listId, string email_address)
        {
            return string.Format("lists/{0}/members/{1}", listId, Util.CalculateSubscriberHash(email_address));
        }
        /// <summary>
        /// The resource endpoint for deleting a member from a list
        /// <param name="listId">List Id</param>
        /// <param name="email_address">Email Addres of the member</param>        
        /// </summary>        
        public static string MembersDelete(string listId, string email_address)
        {
            return string.Format("lists/{0}/members/{1}", listId, Util.CalculateSubscriberHash(email_address));
        }
        #endregion

        #region Batch
        /// <summary>
        /// The resource endpoint for creating a batch operation
        /// </summary>
        public static string BatchCreate()
        {
            return "batches";
        }
        /// <summary>
        /// The resource endpoint for get a list of batch requests
        /// </summary>        
        public static string BatchReadAll()
        {
            return "batches";
        }
        /// <summary>
        /// The resource endpoint for getting the status of a batch operation request
        /// <para>{0} = Batch Id</para>
        /// </summary>        
        public static string BatchRead(string batchId)
        {
            return string.Format("batches/{0}", batchId);
        }
        #endregion
    }
}
