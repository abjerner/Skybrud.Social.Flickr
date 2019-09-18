using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Flickr.Models.Places;

namespace Skybrud.Social.Flickr.Responses.Places {
    
    /// <summary>
    /// Class representing a response from the <c>flickr.places.find</c> Flickr API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.places.find.html</cref>
    /// </see>
    public class FlickrPlacesFindResponse : FlickrResponse<FlickrPlacesFindResponseBody> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> the response should be based on.</param>
        private FlickrPlacesFindResponse(IHttpResponse response) : base(response) {
            Body = ParseXmlElement(response.Body, FlickrPlacesFindResponseBody.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrPlacesFindResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrPlacesFindResponse"/>.</returns>
        public static FlickrPlacesFindResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrPlacesFindResponse(response);
        }

        #endregion
    
    }

}