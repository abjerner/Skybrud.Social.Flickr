using System;
using System.Collections.Specialized;
using Skybrud.Social.Flickr.OAuth;
using Skybrud.Social.Http;

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
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.people.findByUsername.html</cref>
        /// </see>
        public SocialHttpResponse FindByUsername(string username) {
            if (String.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new SocialHttpQueryString {
                {"method", "flickr.people.findByUsername"},
                {"username", username}
            });
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user to fetch information about.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.people.getInfo.html</cref>
        /// </see>
        public SocialHttpResponse GetInfo(string userId) {
            if (String.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException(nameof(userId));
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new SocialHttpQueryString {
                {"method", "flickr.people.getInfo"},
                {"user_id", userId}
            });
        }

        #endregion

    }

}