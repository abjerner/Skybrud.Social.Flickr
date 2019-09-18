using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Flickr.Models.People;

namespace Skybrud.Social.Flickr.Responses.People {

    /// <summary>
    /// Class representing the response of a request to the Flickr API for getting a person.
    /// </summary>
    public class FlickrGetPersonResponse : FlickrResponse<FlickrGetPersonResponseBody> {

        #region Constructors

        private FlickrGetPersonResponse(IHttpResponse response) : base(response) {
            Body = ParseXmlElement(response.Body, FlickrGetPersonResponseBody.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrGetPersonResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrGetPersonResponse"/>.</returns>
        public static FlickrGetPersonResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrGetPersonResponse(response);
        }

        #endregion
    
    }

}