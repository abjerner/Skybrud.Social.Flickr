using Skybrud.Social.Flickr.Objects.Places;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.Places {
    
    public class FlickrPlacesFindResponse : FlickrResponse<FlickrPlacesFindResponseBody> {

        #region Constructors

        private FlickrPlacesFindResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="FlickrPlacesFindResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="FlickrPlacesFindResponse"/>.</returns>
        public static FlickrPlacesFindResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new FlickrPlacesFindResponse(response) {
                Body = ParseXmlElement(response.Body, FlickrPlacesFindResponseBody.Parse)
            };

        }

        #endregion
    
    }

}