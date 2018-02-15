using System;
using Skybrud.Social.Flickr.Models.People;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.People {

    /// <summary>
    /// Class representing the response of a request to the Flickr API for getting a person.
    /// </summary>
    public class FlickrGetPersonResponse : FlickrResponse<FlickrGetPersonResponseBody> {

        #region Constructors

        private FlickrGetPersonResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseXmlElement(response.Body, FlickrGetPersonResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrGetPersonResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrGetPersonResponse"/>.</returns>
        public static FlickrGetPersonResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrGetPersonResponse(response);
        }

        #endregion
    
    }

}