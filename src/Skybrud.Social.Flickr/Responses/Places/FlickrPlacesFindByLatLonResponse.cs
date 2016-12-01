using Skybrud.Social.Flickr.Objects.Places;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.Places {
    
    public class FlickrPlacesFindByLatLonResponse : FlickrResponse<FlickrPlacesFindByLatLonResponseBody> {

        #region Constructors

        private FlickrPlacesFindByLatLonResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="FlickrPlacesFindByLatLonResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="FlickrPlacesFindByLatLonResponse"/>.</returns>
        public static FlickrPlacesFindByLatLonResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new FlickrPlacesFindByLatLonResponse(response) {
                Body = ParseXmlElement(response.Body, FlickrPlacesFindByLatLonResponseBody.Parse)
            };

        }

        #endregion
    
    }

}