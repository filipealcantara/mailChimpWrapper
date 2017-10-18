using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailChimpWrapper.Helpers
{
    /// <summary>
    /// A custom validate attribute for nested objects.
    /// Solution found in http://www.technofattie.com/2011/10/05/recursive-validation-using-dataannotations.html
    /// </summary>
    internal class ValidateObjectAttribute : ValidationAttribute
    {
        /// <summary>
        /// Check if the value is valid of this property
        /// </summary>
        /// <param name="value">The value to be checked</param>
        /// <param name="validationContext">The validation context</param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(value, null, null);

            Validator.TryValidateObject(value, context, results, true);

            if (results.Count != 0)
            {
                var compositeResults = new CompositeValidationResult(string.Format("Validation for {0} failed!", validationContext.DisplayName));
                results.ForEach(compositeResults.AddResult);

                return compositeResults;
            }

            return ValidationResult.Success;
        }
    }

    /// <summary>
    /// Custom class to contain the result of the validation
    /// </summary>
    internal class CompositeValidationResult : ValidationResult
    {
        private readonly List<ValidationResult> _results = new List<ValidationResult>();
        /// <summary>
        /// The results from the the validation
        /// </summary>
        public IEnumerable<ValidationResult> Results
        {
            get
            {
                return _results;
            }
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="errorMessage">The string error from the validation</param>
        public CompositeValidationResult(string errorMessage) : base(errorMessage) { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errorMessage">The string error from the validation</param>
        /// <param name="memberNames">All the members non-validated</param>
        public CompositeValidationResult(string errorMessage, IEnumerable<string> memberNames) : base(errorMessage, memberNames) { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validationResult"></param>
        protected CompositeValidationResult(ValidationResult validationResult) : base(validationResult) { }
        /// <summary>
        /// Add a validationResult on the list of errors
        /// </summary>
        /// <param name="validationResult"></param>
        public void AddResult(ValidationResult validationResult)
        {
            _results.Add(validationResult);
        }
    }
}
