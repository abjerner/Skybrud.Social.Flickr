using Skybrud.Social.Flickr.Objects.Photos;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.Photos {

    /// <summary>
    /// Class representing the response of a request to the Flickr API for uploading a photo.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/upload.api.html</cref>
    /// </see>
    public class FlickrUploadPhotoResponse : FlickrResponse<FlickrUploadPhotoResponseBody> {

        #region Constructors

        private FlickrUploadPhotoResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="FlickrUploadPhotoResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="FlickrUploadPhotoResponse"/>.</returns>
        public static FlickrUploadPhotoResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new FlickrUploadPhotoResponse(response) {
                Body = ParseXml(response.Body, FlickrUploadPhotoResponseBody.Parse)
            };

        }

        #endregion
    
    }

}