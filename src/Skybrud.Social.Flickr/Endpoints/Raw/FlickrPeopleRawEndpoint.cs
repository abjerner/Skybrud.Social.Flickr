using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Flickr.OAuth;

namespace Skybrud.Social.Flickr.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>People</strong> Flickr endpoint.
    /// </summary>
    public class FlickrPeopleRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr OAuth client.
        /// </summary>
        public FlickrOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FlickrPeopleRawEndpoint(FlickrOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user to lookup.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.people.findByUsername.html</cref>
        /// </see>
        public IHttpResponse FindByUsername(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return Client.Get("https://api.flickr.com/services/rest", new HttpQueryString {
                {"method", "flickr.people.findByUsername"},
                {"username", username}
            });
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user to fetch information about.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.people.getInfo.html</cref>
        /// </see>
        public IHttpResponse GetInfo(string userId) {
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException(nameof(userId));
            return Client.Get("https://api.flickr.com/services/rest", new HttpQueryString {
                {"method", "flickr.people.getInfo"},
                {"user_id", userId}
            });
        }

        #endregion

    }

}