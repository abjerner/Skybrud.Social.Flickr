using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Flickr.Models.Photos;

namespace Skybrud.Social.Flickr.Responses.Photos {

    /// <summary>
    /// Class representing the response of a request to the Flickr API for getting information about a photo.
    /// </summary>
    public class FlickrGetPhotoInfoResponse : FlickrResponse<FlickrGetPhotoResponseBody> {

        #region Constructors

        private FlickrGetPhotoInfoResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseXmlElement(response.Body, FlickrGetPhotoResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrGetPhotoInfoResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrGetPhotoInfoResponse"/>.</returns>
        public static FlickrGetPhotoInfoResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrGetPhotoInfoResponse(response);
        }

        #endregion
    
    }

}