using Skybrud.Social.Flickr.Objects.People;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.People {

    public class FlickrFindByUsernameResponse : FlickrResponse<FlickrFindByUsernameResponseBody> {

        #region Constructors

        private FlickrFindByUsernameResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="FlickrFindByUsernameResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="FlickrFindByUsernameResponse"/>.</returns>
        public static FlickrFindByUsernameResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new FlickrFindByUsernameResponse(response) {
                Body = ParseXmlElement(response.Body, FlickrFindByUsernameResponseBody.Parse)
            };

        }

        #endregion
    
    }



}