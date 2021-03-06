﻿using MailChimpWrapper.Endpoints;
using MailChimpWrapper.Helpers;
using MailChimpWrapper.Model;
using MailChimpWrapper.Model.Batch;
using MailChimpWrapper.Model.Batch.Filters;
using MailChimpWrapper.Model.Batch.Response;
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
    /// Class that encapsulates all methods from mailchimp relative to Batches
    /// </summary>
    public class BatchAction : BaseAction
    {
        #region Constructor
        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="apiKey">Client API Key generated by mailchimp</param>
        public BatchAction(string apiKey) : base(apiKey)
        {
        }
        #endregion

        #region Create
        /// <summary>
        /// Create a batch on mailchimp
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public MailChimpWrapperResponse<BatchCreateResponseModel> Create(BatchCreateModel member)
        {
            try
            {
                // Initialize the RestRequest from RestSharp.Newtonsoft so the serializer will user Newtonsoft defaults.
                var request = new RestRequest(ResourcesEndpoints.BatchCreate(), Method.POST);
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
                        return new MailChimpWrapperResponse<BatchCreateResponseModel>
                        {
                            objectRespose = JsonConvert.DeserializeObject<BatchCreateResponseModel>(response.Content)
                        };

                    // If an error occurs, encapsulates the error in MailChimpWrapperResponse
                    var errorContent = JsonConvert.DeserializeObject<ErrorModel>(response.Content);
                    return new MailChimpWrapperResponse<BatchCreateResponseModel>
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
                return new MailChimpWrapperResponse<BatchCreateResponseModel>
                {
                    hasErrors = true,
                    error = error
                };
            }
            catch (Exception ex)
            {
                return ErrorResponse<BatchCreateResponseModel>(ex);
            }
        }
        #endregion

        #region Read
        /// <summary>
        /// Read all members from a list on mailchimp.
        /// </summary>        
        /// <param name="options">The options to filter the lists result.</param>
        /// <returns></returns>
        public MailChimpWrapperResponse<BatchReadAllResponseModel> ReadAll(BatchReadAllOptions options = null)
        {
            try
            {
                // Adds the resource
                var request = new RestRequest(ResourcesEndpoints.BatchReadAll(), Method.GET);
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
                    return new MailChimpWrapperResponse<BatchReadAllResponseModel>
                    {
                        objectRespose = JsonConvert.DeserializeObject<BatchReadAllResponseModel>(response.Content)
                    };

                // If an error occurs, encapsulates the error in MailChimpWrapperResponse
                var errorContent = JsonConvert.DeserializeObject<ErrorModel>(response.Content);
                return new MailChimpWrapperResponse<BatchReadAllResponseModel>
                {
                    hasErrors = true,
                    error = errorContent
                };
            }
            catch (Exception ex)
            {
                return ErrorResponse<BatchReadAllResponseModel>(ex);
            }
        }

        /// <summary>
        /// Read the member info
        /// </summary>
        /// <param name="batchId">The id of the batch to be read</param>
        /// <param name="options">Options to filter the response</param>
        public MailChimpWrapperResponse<BatchReadResponseModel> Read(string batchId, BatchReadOptions options = null)
        {
            try
            {
                // Adds the resource
                var request = new RestRequest(ResourcesEndpoints.BatchRead(batchId), Method.GET);
                request.JsonSerializer = new CustomNewtonsoftSerializer(new JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });
                // Check if options was passed
                if (options != null)
                    SetReadOptions(ref request, options);

                // Execute the request
                var response = restClient.Execute(request);

                // If the request return ok, then return MailChimpWrapperResponse with deserialized object
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return new MailChimpWrapperResponse<BatchReadResponseModel>
                    {
                        objectRespose = JsonConvert.DeserializeObject<BatchReadResponseModel>(response.Content)
                    };

                // If an error occurs, encapsulates the error in MailChimpWrapperResponse
                var errorContent = JsonConvert.DeserializeObject<ErrorModel>(response.Content);
                return new MailChimpWrapperResponse<BatchReadResponseModel>
                {
                    hasErrors = true,
                    error = errorContent
                };
            }
            catch (Exception ex)
            {
                return ErrorResponse<BatchReadResponseModel>(ex);
            }

        }
        #endregion

        #region Private Auxiliary Methods
        /// <summary>
        /// Set on the request all the filters from ListReadAllOptions
        /// </summary>
        /// <param name="request">Request that will be used to call the API</param>
        /// <param name="options">Object with the options of filter for mailchimp call</param>
        private void SetReadAllOptions(ref RestRequest request, BatchReadAllOptions options)
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

            if(options.count != null)
                request.AddQueryParameter("count", ((int)options.count).ToString());

            if (options.offset != null)
                request.AddQueryParameter("offset", ((int)options.offset).ToString());
        }
        /// <summary>
        /// Set on the request all the filters from ListReadAllOptions
        /// </summary>
        /// <param name="request">Request that will be used to call the API</param>
        /// <param name="options">Object with the options of filter for mailchimp call</param>
        private void SetReadOptions(ref RestRequest request, BatchReadOptions options)
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
        }
        #endregion
    }
}