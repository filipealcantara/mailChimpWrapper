namespace MailChimpWrapper.Model.Members.Response
{
    /// <summary>
    /// The members note object in members create response
    /// </summary>
    public class MembersNoteModel
    {
        /// <summary>
        /// The note id.
        /// </summary>
        public int note_id { get; set; }
        /// <summary>
        /// The date the note was created.
        /// </summary>
        public string created_at { get; set; }
        /// <summary>
        /// The author of the note.
        /// </summary>
        public string created_by { get; set; }
        /// <summary>
        /// The content of the note.
        /// </summary>
        public string note { get; set; }
    }
}
