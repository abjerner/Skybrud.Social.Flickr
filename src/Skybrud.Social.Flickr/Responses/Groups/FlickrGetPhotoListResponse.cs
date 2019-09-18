using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Flickr.Models.Groups.Pools;

namespace Skybrud.Social.Flickr.Responses.Groups {

    /// <summary>
    /// Class representing the response of a request to the Flickr API for getting a list of photos.
    /// </summary>
    public class FlickrGetPhotoListResponse : FlickrResponse<FlickrPhotosResult> {

        #region Constructors

        private FlickrGetPhotoListResponse(IHttpResponse response) : base(response) {
            Body = ParseXmlElement(response.Body, FlickrPhotosResult.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrGetPhotoListResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrGetPhotoListResponse"/>.</returns>
        public static FlickrGetPhotoListResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrGetPhotoListResponse(response);
        }

        #endregion
    
    }

}