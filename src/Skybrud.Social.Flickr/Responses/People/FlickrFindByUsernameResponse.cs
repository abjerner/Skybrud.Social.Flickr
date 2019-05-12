using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Flickr.Models.People;

namespace Skybrud.Social.Flickr.Responses.People {

    public class FlickrFindByUsernameResponse : FlickrResponse<FlickrFindByUsernameResponseBody> {

        #region Constructors

        private FlickrFindByUsernameResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseXmlElement(response.Body, FlickrFindByUsernameResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrFindByUsernameResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrFindByUsernameResponse"/>.</returns>
        public static FlickrFindByUsernameResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrFindByUsernameResponse(response);
        }

        #endregion
    
    }



}