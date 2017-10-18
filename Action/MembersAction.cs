﻿using MailChimpWrapper.Endpoints;
using MailChimpWrapper.Helpers;
using MailChimpWrapper.Model;
using MailChimpWrapper.Model.Common;
using MailChimpWrapper.Model.Members;
using MailChimpWrapper.Model.Members.Filters;
using MailChimpWrapper.Model.Members.Response;
using MailChimpWrapper.Serializers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static MailChimpWrapper.Action.Common;

namespace MailChimpWrapper.Action
{
    /// <summary>
    /// Class that encapsulates all methods from mailchimp
    /// relative to Members
    /// </summary>
    public class MembersAction : BaseAction
    {
        #region Constructor
        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="apiKey">Client API Key generated by mailchimp</param>
        public MembersAction(string apiKey) : base(apiKey)
        {
        }
        #endregion

        #region Create
        /// <summary>
        /// Creates a member on mailchimp
        /// </summary>
        /// <param name="listId">The Id of the list to be add the merge field</param>
        /// <param name="member">The model that contains all info about the member that will be created</param>
        /// <returns></returns>
        public MailChimpWrapperResponse<MembersCreateResponseModel> Create(string listId, MembersCreateModel member)
        {
            try
            {
                // Initialize the RestRequest from RestSharp.Newtonsoft so the serializer will user Newtonsoft defaults.
                var request = new RestRequest(ResourcesEndpoints.MembersCreate(listId), Method.POST);
                // Adds the resource
                request.AddHeader("content-type", "application/json");
                request.JsonSerializer = new CustomNewtonsoftSerializer(new JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });

                // Validates the object
                var validationContext = new ValidationContext(member, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(member, validationContext, validationResults, false);

                if (isValid)
                {
                    request.AddJsonBody(member);
                    // Execute the request
                    var response = restClient.Execute(request);

                    // If the request return ok, then return MailChimpWrapperResponse with deserialized object
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return new MailChimpWrapperResponse<MembersCreateResponseModel>
                        {
                            objectRespose = JsonConvert.DeserializeObject<MembersCreateResponseModel>(response.Content)
                        };

                    // If an error occurs, encapsulates the error in MailChimpWrapperResponse
                    var errorContent = JsonConvert.DeserializeObject<ErrorModel>(response.Content);
                    return new MailChimpWrapperResponse<MembersCreateResponseModel>
                    {
                        hasErrors = true,
                        error = errorContent
                    };
                }

                // If the object was not valid then creates and ErrorModel to send back
                var error = new ErrorModel
                {
                    type = "Internal Method Error.",
                    title = "One or more fields were not validated. Look in detail for more information",
                    status = 0,
                    detail = Util.GetValidationsErrors(validationResults)
                };
                return new MailChimpWrapperResponse<MembersCreateResponseModel>
                {
                    hasErrors = true,
                    error = error
                };
            }
            catch (Exception ex)
            {
                return ErrorResponse<MembersCreateResponseModel>(ex);
            }
        }
        #endregion

        #region Read
        /// <summary>
        /// Read all members from a list on mailchimp.
        /// </summary>
        /// <param name="listId">The listId to get the merge fields from.</param>
        /// <param name="options">The options to filter the lists result.</param>
        /// <returns></returns>
        public MailChimpWrapperResponse<MembersReadAllResponseModel> ReadAll(string listId, MembersReadAllOptions options = null)
        {
            try
            {
                // Adds the resource
                var request = new RestRequest(ResourcesEndpoints.MembersReadAll(listId), Method.GET);
                request.JsonSerializer = new CustomNewtonsoftSerializer(new JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });

                // Check if options was passed
                if (options != null)
                    SetReadAllOptions(ref request, options);

                // Execute the request
                var response = restClient.Execute(request);

                // If the request return ok, then return MailChimpWrapperResponse with deserialized object
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return new MailChimpWrapperResponse<MembersReadAllResponseModel>
                    {
                        objectRespose = JsonConvert.DeserializeObject<MembersReadAllResponseModel>(response.Content)
                    };

                // If an error occurs, encapsulates the error in MailChimpWrapperResponse
                var errorContent = JsonConvert.DeserializeObject<ErrorModel>(response.Content);
                return new MailChimpWrapperResponse<MembersReadAllResponseModel>
                {
                    hasErrors = true,
                    error = errorContent
                };
            }
            catch (Exception ex)
            {
                return ErrorResponse<MembersReadAllResponseModel>(ex);
            }
        }

        /// <summary>
        /// Read the member info
        /// </summary>
        /// <param name="listId">The id of the list that will be read</param>
        /// <param name="email_address">Email Address to read from mailchimp</param>
        public MailChimpWrapperResponse<MembersReadResponseModel> Read(string listId, string email_address)
        {
            try
            {                
                // Adds the resource
                var request = new RestRequest(ResourcesEndpoints.MembersRead(listId, email_address), Method.GET);
                request.JsonSerializer = new CustomNewtonsoftSerializer(new JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });

                // Execute the request
                var response = restClient.Execute(request);

                // If the request return ok, then return MailChimpWrapperResponse with deserialized object
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return new MailChimpWrapperResponse<MembersReadResponseModel>
                    {
                        objectRespose = JsonConvert.DeserializeObject<MembersReadResponseModel>(response.Content)
                    };

                // If an error occurs, encapsulates the error in MailChimpWrapperResponse
                var errorContent = JsonConvert.DeserializeObject<ErrorModel>(response.Content);
                return new MailChimpWrapperResponse<MembersReadResponseModel>
                {
                    hasErrors = true,
                    error = errorContent
                };
            }
            catch (Exception ex)
            {
                return ErrorResponse<MembersReadResponseModel>(ex);
            }

        }
        #endregion

        #region Update
        /// <summary>
        /// Updates the member by its email_address
        /// </summary>
        /// <param name="listId">The Id of the list to be updated</param>        
        /// <param name="member">The data to update</param>
        /// <returns></returns>
        public MailChimpWrapperResponse<MembersCreateResponseModel> Update(string listId, MembersPatchModel member)
        {
            try
            {                
                // Initialize the RestRequest from RestSharp.Newtonsoft so the serializer will user Newtonsoft defaults.
                var request = new RestRequest(ResourcesEndpoints.MembersUpdate(listId, member.email_address), Method.PATCH);
                // Adds the resource
                request.AddHeader("content-type", "application/json");
                request.JsonSerializer = new CustomNewtonsoftSerializer(new JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });
                request.AddJsonBody(member);
                // Execute the request
                var response = restClient.Execute(request);

                // If the request return ok, then return MailChimpWrapperResponse with deserialized object
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return new MailChimpWrapperResponse<MembersCreateResponseModel>
                    {
                        objectRespose = JsonConvert.DeserializeObject<MembersCreateResponseModel>(response.Content)
                    };

                // If an error occurs, encapsulates the error in MailChimpWrapperResponse
                var errorContent = JsonConvert.DeserializeObject<ErrorModel>(response.Content);
                return new MailChimpWrapperResponse<MembersCreateResponseModel>
                {
                    hasErrors = true,
                    error = errorContent
                };
            }
            catch (Exception ex)
            {
                return ErrorResponse<MembersCreateResponseModel>(ex);
            }
        }
        /// <summary>
        /// Updates Or Adds the member by its email_addres based on MembersPutModel object
        /// </summary>
        /// <param name="listId">The Id of the list to be updated</param>        
        /// <param name="member">The data to update or add if not exist</param>
        /// <returns></returns>
        public MailChimpWrapperResponse<MembersCreateResponseModel> Update(string listId, MembersPutModel member)
        {
            try
            {
                // Initialize the RestRequest from RestSharp.Newtonsoft so the serializer will user Newtonsoft defaults.
                var request = new RestRequest(ResourcesEndpoints.MembersUpdate(listId, member.email_address), Method.PUT);
                // Adds the resource
                request.AddHeader("content-type", "application/json");
                request.JsonSerializer = new CustomNewtonsoftSerializer(new JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });

                // Validates the object
                var validationContext = new ValidationContext(member, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(member, validationContext, validationResults, false);

                if (isValid)
                {
                    request.AddJsonBody(member);
                    // Execute the request
                    var response = restClient.Execute(request);

                    // If the request return ok, then return MailChimpWrapperResponse with deserialized object
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return new MailChimpWrapperResponse<MembersCreateResponseModel>
                        {
                            objectRespose = JsonConvert.DeserializeObject<MembersCreateResponseModel>(response.Content)
                        };

                    // If an error occurs, encapsulates the error in MailChimpWrapperResponse
                    var errorContent = JsonConvert.DeserializeObject<ErrorModel>(response.Content);
                    return new MailChimpWrapperResponse<MembersCreateResponseModel>
                    {
                        hasErrors = true,
                        error = errorContent
                    };
                }

                // If the object was not valid then creates and ErrorModel to send back
                var error = new ErrorModel
                {
                    type = "Internal Method Error.",
                    title = string.Format("Field {0} missing", validationResults[0]?.MemberNames.FirstOrDefault()),
                    status = 0,
                    detail = validationResults[0].ErrorMessage
                };
                return new MailChimpWrapperResponse<MembersCreateResponseModel>
                {
                    hasErrors = true,
                    error = error
                };
            }
            catch (Exception ex)
            {
                return ErrorResponse<MembersCreateResponseModel>(ex);
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete a member based on listId and email_address.
        /// </summary>
        /// <param name="listId">The Id of the list to delete the merge-field.</param>
        /// <param name="email_address">The email address of the member to be deleted</param>
        /// <returns></returns>
        public MailChimpWrapperResponse<CommonDeleteResponseModel> Delete(string listId, string email_address)
        {
            try
            {                
                // Adds the resource
                var request = new RestRequest(ResourcesEndpoints.MembersDelete(listId, email_address), Method.DELETE);

                // Execute the request
                var response = restClient.Execute(request);

                // If the request return ok, then return MailChimpWrapperResponse with deserialized object
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return new MailChimpWrapperResponse<CommonDeleteResponseModel>
                    {
                        objectRespose = new CommonDeleteResponseModel()
                    };

                // If an error occurs, encapsulates the error in MailChimpWrapperResponse
                var errorContent = JsonConvert.DeserializeObject<ErrorModel>(response.Content);
                return new MailChimpWrapperResponse<CommonDeleteResponseModel>
                {
                    hasErrors = true,
                    error = errorContent
                };
            }
            catch (Exception ex)
            {
                return ErrorResponse<CommonDeleteResponseModel>(ex);
            }
        }
        #endregion

        #region Private Auxiliary Methods
        /// <summary>
        /// Set on the request all the filters from ListReadAllOptions
        /// </summary>
        /// <param name="request">Request that will be used to call the API</param>
        /// <param name="options">Object with the options of filter for mailchimp call</param>
        private void SetReadAllOptions(ref RestRequest request, MembersReadAllOptions options)
        {
            if (options.fields != null && options.fields.Count > 0)
            {
                var fieldsString = "";
                for (var i = 0; i < options.fields.Count; i++)
                {
                    if (i < options.fields.Count - 1)
                        fieldsString += options.fields[i] + ",";
                    else
                        fieldsString += options.fields[i];
                }
                request.AddQueryParameter("fields", fieldsString);
            }

            if (options.exclude_fields != null && options.exclude_fields.Count > 0)
            {
                var excludeFieldsString = "";
                for (var i = 0; i < options.exclude_fields.Count; i++)
                {
                    if (i < options.fields.Count - 1)
                        excludeFieldsString += options.exclude_fields[i] + ",";
                    else
                        excludeFieldsString += options.exclude_fields[i];
                }
                request.AddQueryParameter("exclude_fields", excludeFieldsString);
            }

            if (options.count != null)
                request.AddQueryParameter("count", ((int)options.count).ToString());

            if (options.offset != null)
                request.AddQueryParameter("offset", ((int)options.offset).ToString());

            if (!string.IsNullOrEmpty(options.email_type))
                request.AddQueryParameter("email_type", options.email_type);

            if (!string.IsNullOrEmpty(options.status))
                request.AddQueryParameter("status", options.status);

            if (!string.IsNullOrEmpty(options.since_timestamp_opt))
                request.AddQueryParameter("since_timestamp_opt", options.since_timestamp_opt);

            if (!string.IsNullOrEmpty(options.before_timestamp_opt))
                request.AddQueryParameter("before_timestamp_opt", options.before_timestamp_opt);

            if (!string.IsNullOrEmpty(options.since_last_changed))
                request.AddQueryParameter("since_last_changed", options.since_last_changed);

            if (!string.IsNullOrEmpty(options.before_last_changed))
                request.AddQueryParameter("before_last_changed", options.before_last_changed);
        }
        #endregion
    }
}
