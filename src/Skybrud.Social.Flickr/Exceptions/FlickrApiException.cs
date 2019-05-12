using System;
using System.Net;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Flickr.Exceptions {
    
    public class FlickrApiException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets the HTTP status code returned by the Flickr API.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        #endregion

        #region Constructors

        public FlickrApiException(IHttpResponse response, int code, string message) : base("The Flickr API returned an error: " + message + " (code: " + code + ")") {
            Response = response;
            StatusCode = response.StatusCode;
        }

        #endregion

    }

}