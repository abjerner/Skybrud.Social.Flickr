using Skybrud.Social.Flickr.Objects.Photosets;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.Photosets {

    /// <summary>
    /// Class representing the response of a request to the Flickr API for getting a list of photosets.
    /// </summary>
    public class FlickrGetPhotosetListResponse : FlickrResponse<FlickrGetPhotosetListResponseBody> {

        #region Properties

        /// <summary>
        /// Gets a reference to the array of photosets. Same as <code>Body.Photosets</code>.
        /// </summary>
        public FlickrPhotosetList Photosets {
            get { return Body.Photosets; }
        }

        #endregion

        #region Constructors

        private FlickrGetPhotosetListResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="FlickrGetPhotosetListResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="FlickrGetPhotosetListResponse"/>.</returns>
        public static FlickrGetPhotosetListResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new FlickrGetPhotosetListResponse(response) {
                Body = ParseXmlElement(response.Body, FlickrGetPhotosetListResponseBody.Parse)
            };

        }

        #endregion
    
    }

}