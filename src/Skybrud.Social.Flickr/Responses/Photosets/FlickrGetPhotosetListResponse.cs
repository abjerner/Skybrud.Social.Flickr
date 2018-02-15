using System;
using Skybrud.Social.Flickr.Objects.Photosets;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.Photosets {

    /// <summary>
    /// Class representing the response of a request to the Flickr API for getting a list of photosets.
    /// </summary>
    public class FlickrGetPhotosetListResponse : FlickrResponse<FlickrGetPhotosetListResponseBody> {

        #region Properties

        /// <summary>
        /// Gets a reference to the array of photosets. Same as <c>Body.Photosets</c>.
        /// </summary>
        public FlickrPhotosetList Photosets => Body.Photosets;

        #endregion

        #region Constructors

        private FlickrGetPhotosetListResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseXmlElement(response.Body, FlickrGetPhotosetListResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrGetPhotosetListResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrGetPhotosetListResponse"/>.</returns>
        public static FlickrGetPhotosetListResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrGetPhotosetListResponse(response);
        }

        #endregion
    
    }

}