using Skybrud.Social.Flickr.Objects.Photosets;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.Photosets {

    /// <summary>
    /// Class representing the response of a request to the Flickr API for getting information about a photoset.
    /// </summary>
    public class FlickrGetPhotosetInfoResponse : FlickrResponse<FlickrGetPhotosetInfoResponseBody> {

        #region Properties

        /// <summary>
        /// Gets a reference to the photoset. Same as <code>Body.Photoset</code>.
        /// </summary>
        public FlickrPhotoset Photoset {
            get { return Body.Photoset; }
        }

        #endregion

        #region Constructors

        private FlickrGetPhotosetInfoResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="FlickrGetPhotosetInfoResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="FlickrGetPhotosetInfoResponse"/>.</returns>
        public static FlickrGetPhotosetInfoResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new FlickrGetPhotosetInfoResponse(response) {
                Body = ParseXmlElement(response.Body, FlickrGetPhotosetInfoResponseBody.Parse)
            };

        }

        #endregion
    
    }

}