using Skybrud.Social.Flickr.Objects.Photos;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.Photos {

    /// <summary>
    /// Class representing the response of a request to the Flickr API for getting information about a photo.
    /// </summary>
    public class FlickrGetPhotoInfoResponse : FlickrResponse<FlickrGetPhotoResponseBody> {

        #region Constructors

        private FlickrGetPhotoInfoResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="FlickrGetPhotoInfoResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="FlickrGetPhotoInfoResponse"/>.</returns>
        public static FlickrGetPhotoInfoResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new FlickrGetPhotoInfoResponse(response) {
                Body = ParseXml(response.Body, FlickrGetPhotoResponseBody.Parse)
            };

        }

        #endregion
    
    }

}