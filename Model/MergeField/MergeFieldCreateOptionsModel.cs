namespace MailChimpWrapper.Model.MergeField
{
    /// <summary>
    /// Options class for merge field create
    /// </summary>
    public class MergeFieldCreateOptionsModel
    {
        /// <summary>
        /// In an address field, the default country code if none supplied.
        /// </summary>
        public int default_country { get; set; }
        /// <summary>
        /// In a phone field, the phone number type: US or International.
        /// </summary>
        public string phone_format { get; set; }
        /// <summary>
        /// In a date or birthday field, the format of the date.
        /// </summary>
        public string date_format { get; set; }
        /// <summary>
        /// In a radio or dropdown non-group field, the available options for members to pick from.
        /// </summary>
        public string[] choices { get; set; }
        /// <summary>
        /// In a text field, the default length of the text field.
        /// </summary>
        public int size { get; set; }
    }
}