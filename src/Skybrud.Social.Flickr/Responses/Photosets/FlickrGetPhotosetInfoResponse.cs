using System;
using Skybrud.Social.Flickr.Objects.Photosets;
using Skybrud.Social.Http;

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

        private FlickrGetPhotosetInfoResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseXmlElement(response.Body, FlickrGetPhotosetInfoResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrGetPhotosetInfoResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrGetPhotosetInfoResponse"/>.</returns>
        public static FlickrGetPhotosetInfoResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrGetPhotosetInfoResponse(response);
        }

        #endregion
    
    }

}