using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Flickr.Models.Places;

namespace Skybrud.Social.Flickr.Responses.Places {

    /// <summary>
    /// Class representing a response from the <c>flickr.places.getInfo</c> Flickr API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.places.getInfo.html</cref>
    /// </see>
    public class FlickrPlacesGetInfoResponse : FlickrResponse<FlickrPlacesGetInfoResponseBody> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> the response should be based on.</param>
        private FlickrPlacesGetInfoResponse(IHttpResponse response) : base(response) {

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
        /// <returns>An instance of <see cref="FlickrPlacesGetInfoResponse"/>.</returns>
        public static FlickrPlacesGetInfoResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrPlacesGetInfoResponse(response);
        }

        #endregion
    
    }

}