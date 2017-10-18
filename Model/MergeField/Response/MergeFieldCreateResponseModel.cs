namespace MailChimpWrapper.Model.MergeField.Response
{
    /// <summary>
    /// Class to represent the create response from mailchimp of a Merge Field
    /// </summary>
    public class MergeFieldCreateResponseModel : MergeFieldCreateModel
    {
        /// <summary>
        /// An unchanging id for the merge field.
        /// </summary>
        public int merge_id { get; set; }
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
