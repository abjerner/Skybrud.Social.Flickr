using System;
using Skybrud.Social.Flickr.Models.Urls;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.Urls {

    /// <summary>
    /// Class representing a response from the <c>flickr.places.getInfo</c> Flickr API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.places.getInfo.html</cref>
    /// </see>
    public class FlickrUrlsLookupUserResponse : FlickrResponse<FlickrUrlsLookupUserResponseBody> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> the response should be based on.</param>
        private FlickrUrlsLookupUserResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseXmlElement(response.Body, FlickrUrlsLookupUserResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrUrlsLookupUserResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrUrlsLookupUserResponse"/>.</returns>
        public static FlickrUrlsLookupUserResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrUrlsLookupUserResponse(response);
        }

        #endregion
    
    }

}