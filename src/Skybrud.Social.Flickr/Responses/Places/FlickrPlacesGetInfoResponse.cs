﻿using Skybrud.Social.Flickr.Objects.Places;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.Places {

    /// <summary>
    /// Class representing a response from the <code>flickr.places.getInfo</code> Flickr API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.places.getInfo.html</cref>
    /// </see>
    public class FlickrPlacesGetInfoResponse : FlickrResponse<FlickrPlacesGetInfoResponseBody> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> the response should be based on.</param>
        private FlickrPlacesGetInfoResponse(SocialHttpResponse response)
            : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseXmlElement(response.Body, FlickrPlacesGetInfoResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrPlacesGetInfoResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="FlickrPlacesGetInfoResponse"/>.</returns>
        public static FlickrPlacesGetInfoResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new FlickrPlacesGetInfoResponse(response);
        }

        #endregion
    
    }

}