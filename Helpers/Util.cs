using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace MailChimpWrapper.Helpers
{
    /// <summary>
    /// Encapsulates useful methods that can be used through the lib
    /// </summary>
    internal static class Util
    {
        /// <summary>
        /// Calculates the MD5 Hash from a string
        /// </summary>
        /// <param name="input">a string to be computed the md5 hash</param>
        /// <returns></returns>
        public static string CalculateSubscriberHash(string input)
        {
            // Calculate MD5 hash from input.
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // Convert byte array to hex string.
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }
        /// <summary>
        /// Get a string representation of all the errors occurred when trying to validate and object
        /// </summary>
        /// <param name="results">The ValidationResult list containing the errors</param>
        /// <returns></returns>
        public static string GetValidationsErrors(IEnumerable<ValidationResult> results)
        {
            string detailError = "";
            foreach (var validationResult in results)
            {
                if (validationResult is CompositeValidationResult)
                {
                    foreach (var item in ((CompositeValidationResult)validationResult).Results)
                    {
                        detailError += item.ErrorMessage + " ";
                    }
                }
                else
                {
                    detailError += validationResult.ErrorMessage + " ";
                }
            }
            return detailError;
        }
    }
}
