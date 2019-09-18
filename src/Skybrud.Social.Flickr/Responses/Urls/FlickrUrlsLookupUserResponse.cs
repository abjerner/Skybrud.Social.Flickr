using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Flickr.Models.Urls;

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
        /// <param name="response">The instance of <see cref="IHttpResponse"/> the response should be based on.</param>
        private FlickrUrlsLookupUserResponse(IHttpResponse response) : base(response) {
            Body = ParseXmlElement(response.Body, FlickrUrlsLookupUserResponseBody.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrUrlsLookupUserResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrUrlsLookupUserResponse"/>.</returns>
        public static FlickrUrlsLookupUserResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrUrlsLookupUserResponse(response);
        }

        #endregion
    
    }

}