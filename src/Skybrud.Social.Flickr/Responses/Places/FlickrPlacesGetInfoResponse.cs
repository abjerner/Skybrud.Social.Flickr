using Skybrud.Social.Flickr.Objects.Places;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.Places {
    
    public class FlickrPlacesGetInfoResponse : FlickrResponse<FlickrPlacesGetInfoResponseBody> {

        #region Constructors

        private FlickrPlacesGetInfoResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="FlickrPlacesGetInfoResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="FlickrPlacesGetInfoResponse"/>.</returns>
        public static FlickrPlacesGetInfoResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new FlickrPlacesGetInfoResponse(response) {
                Body = ParseXmlElement(response.Body, FlickrPlacesGetInfoResponseBody.Parse)
            };

        }

        #endregion
    
    }

}