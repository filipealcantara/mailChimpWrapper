namespace MailChimpWrapper.Model.List.Response
{
    /// <summary>
    /// Class that represents the response model from MailChimp API
    /// </summary>
    public class ListCreateResponseModel : ListCreateModel
    {
        /// <summary>
        /// A string that uniquely identifies this list.
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// The date and time that this list was created.
        /// </summary>
        public string date_created { get; set; }
        /// <summary>
        /// An auto-generated activity score for the list (0-5).
        /// </summary>
        public int list_rating { get; set; }
        /// <summary>
        /// Our EepURL shortened version of this list’s subscribe form.
        /// </summary>
        public string subscribe_url_short { get; set; }
        /// <summary>
        /// The full version of this list’s subscribe form (host will vary).
        /// </summary>
        public string subscribe_url_long { get; set; }
        /// <summary>
        /// The list’s Email Beamer address.
        /// </summary>
        public string beamer_address { get; set; }
        /// <summary>
        /// Any list-specific modules installed for this list.
        /// </summary>
        public object[] modules { get; set; }
        /// <summary>
        /// Stats for the list. Many of these are cached for at least five minutes.
        /// </summary>
        public ListStatsModel stats { get; set; }
        /// <summary>
        /// A list of link types and descriptions for the API schema documents.
        /// </summary>
        public LinksModel[] _links { get; set; }
    }
}
