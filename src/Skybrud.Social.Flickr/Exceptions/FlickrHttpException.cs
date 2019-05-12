using System;
using System.Net;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Flickr.Exceptions {
    
    public class FlickrHttpException : Exception {

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

        public FlickrHttpException(IHttpResponse response) : base("Invalid response received from the Flickr API (Status: " + ((int) response.StatusCode) + ")") {
            Response = response;
            StatusCode = response.StatusCode;
        }

        #endregion

    }

}