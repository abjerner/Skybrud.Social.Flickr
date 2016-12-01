using Skybrud.Social.Flickr.Objects.People;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.People {

    public class FlickrGetPersonResponse : FlickrResponse<FlickrGetPersonResponseBody> {

        #region Constructors

        private FlickrGetPersonResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="FlickrGetPersonResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="FlickrGetPersonResponse"/>.</returns>
        public static FlickrGetPersonResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new FlickrGetPersonResponse(response) {
                Body = ParseXmlElement(response.Body, FlickrGetPersonResponseBody.Parse)
            };

        }

        #endregion
    
    }

}