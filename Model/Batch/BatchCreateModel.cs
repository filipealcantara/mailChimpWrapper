namespace MailChimpWrapper.Model.Batch
{
    /// <summary>
    /// The class model to create a batch in mailchimp API
    /// </summary>
    public class BatchCreateModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BatchCreateModel() {}
        /// <summary>
        /// Constructor with the required parameters
        /// </summary>
        /// <param name="operations">An array of objects that describes operations to perform.</param>
        public BatchCreateModel(OperationModel[] operations)
        {
            this.operations = operations;
        }
        /// <summary>
        /// An array of objects that describes operations to perform.
        /// </summary>
        public OperationModel[] operations { get; set; }
    }
}
