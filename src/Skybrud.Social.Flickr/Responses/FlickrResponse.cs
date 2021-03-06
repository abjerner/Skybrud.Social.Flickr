﻿using System.Net;
using System.Xml.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Flickr.Exceptions;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Responses {

    /// <summary>
    /// Class representing a response from the Flickr API.
    /// </summary>
    public class FlickrResponse : HttpResponseBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> the response should be based on.</param>
        protected FlickrResponse(IHttpResponse response) : base(response) {
            ValidateResponse(response);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(IHttpResponse response) {

            // Parse the OAuth error
            if (response.Body.StartsWith("oauth_problem=")) throw new FlickrOAuthException(response);

            // Throw a "FlickrHttpException" if we have an error at the HTTP level
            if (response.StatusCode != HttpStatusCode.OK) throw new FlickrHttpException(response);

            // Some further validation for XML responses
            if (response.Body.StartsWith("<")) ValidateXmlResponse(response);
        
        }

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateXmlResponse(IHttpResponse response) {

            // Parse the XML
            XElement xResponse = XElement.Parse(response.Body);

            // Get the status of the response
            string status = xResponse.GetAttributeValue("stat");

            // Return if not "ok"
            if (status == "ok") return;

            // Otherwise "status" should be "fail", and there should be an "err" element 
            XElement xError = xResponse.Element("err");
            int code = xError.GetAttributeValueAsInt32("code");
            string message = xError.GetAttributeValue("msg");
            throw new FlickrApiException(response, code, message);
            
        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Flickr API.
    /// </summary>
    public class FlickrResponse<T> : FlickrResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> the response should be based on.</param>
        protected FlickrResponse(IHttpResponse response) : base(response) { }

        #endregion

    }

}