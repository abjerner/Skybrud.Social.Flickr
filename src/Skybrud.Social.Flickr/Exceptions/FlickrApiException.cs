using System;
using System.Net;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Exceptions {
    
    public class FlickrApiException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="SocialHttpResponse"/>.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets the HTTP status code returned by the Flickr API.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        #endregion

        #region Constructors

        public FlickrApiException(SocialHttpResponse response, int code, string message) : base("The Flickr API returned an error: " + message + " (code: " + code + ")") {
            Response = response;
            StatusCode = response.StatusCode;
        }

        #endregion

    }

}