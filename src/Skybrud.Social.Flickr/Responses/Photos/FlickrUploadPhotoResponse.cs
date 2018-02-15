using System;
using Skybrud.Social.Flickr.Models.Photos;
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

        private FlickrUploadPhotoResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseXmlElement(response.Body, FlickrUploadPhotoResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrUploadPhotoResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrUploadPhotoResponse"/>.</returns>
        public static FlickrUploadPhotoResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrUploadPhotoResponse(response);
        }

        #endregion
    
    }

}