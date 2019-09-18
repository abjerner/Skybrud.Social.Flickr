using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Flickr.Models.Photosets;

namespace Skybrud.Social.Flickr.Responses.Photosets {

    /// <summary>
    /// Class representing the response of a request to the Flickr API for getting information about a photoset.
    /// </summary>
    public class FlickrGetPhotosetInfoResponse : FlickrResponse<FlickrGetPhotosetInfoResponseBody> {

        #region Properties

        /// <summary>
        /// Gets a reference to the photoset. Same as <c>Body.Photoset</c>.
        /// </summary>
        public FlickrPhotoset Photoset => Body.Photoset;

        #endregion

        #region Constructors

        private FlickrGetPhotosetInfoResponse(IHttpResponse response) : base(response) {
            Body = ParseXmlElement(response.Body, FlickrGetPhotosetInfoResponseBody.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrGetPhotosetInfoResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrGetPhotosetInfoResponse"/>.</returns>
        public static FlickrGetPhotosetInfoResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrGetPhotosetInfoResponse(response);
        }

        #endregion
    
    }

}