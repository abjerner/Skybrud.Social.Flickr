using System;
using System.Net;
using System.Xml.Linq;
using Skybrud.Social.Flickr.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Xml.Extensions;

namespace Skybrud.Social.Flickr.Responses {

    /// <summary>
    /// Class representing a response from the Flickr API.
    /// </summary>
    public class FlickrResponse : SocialResponse {

        #region Constructors

        protected FlickrResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Throw a "FlickrHttpException" if we have an error at the HTTP level
            if (response.StatusCode != HttpStatusCode.OK) throw new FlickrHttpException(response);

            // TODO: We really shouldn't parse the XML both here and when actually parsing the response body into the strongly typed model(s)
            XElement xResponse = XElement.Parse(response.Body);

            // Get the status of the response
            string status = xResponse.GetAttributeValue("stat");

            // Return if not "ok"
            if (status == "ok") return;

            // Otherwise "status" should be "fail", and there should be an "err" element 
            XElement xError = xResponse.Element("err");
            int code = xError.GetAttributeAsInt32("code");
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

        protected FlickrResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}