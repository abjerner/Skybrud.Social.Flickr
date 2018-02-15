using System;
using Skybrud.Social.Flickr.Objects.Places;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.Places {

    /// <summary>
    /// Class representing a response from the <c>flickr.places.findByLatLon</c> Flickr API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.places.findByLatLon.html</cref>
    /// </see>
    public class FlickrPlacesFindByLatLonResponse : FlickrResponse<FlickrPlacesFindByLatLonResponseBody> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> the response should be based on.</param>
        private FlickrPlacesFindByLatLonResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseXmlElement(response.Body, FlickrPlacesFindByLatLonResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrPlacesFindByLatLonResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrPlacesFindByLatLonResponse"/>.</returns>
        public static FlickrPlacesFindByLatLonResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrPlacesFindByLatLonResponse(response);
        }

        #endregion
    
    }

}