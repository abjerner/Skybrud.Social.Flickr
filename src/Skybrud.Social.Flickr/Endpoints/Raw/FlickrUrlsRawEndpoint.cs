using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Flickr.OAuth;

namespace Skybrud.Social.Flickr.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the URLs Flickr endpoint.
    /// </summary>
    public class FlickrUrlsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr OAuth client.
        /// </summary>
        public FlickrOAuthClient Client { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instanced based on the <paramref name="client"/>.
        /// </summary>
        /// <param name="client">An instance of <see cref="FlickrOAuthClient"/> representing the parent OAuth client.</param>
        internal FlickrUrlsRawEndpoint(FlickrOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Return the Flickr ID of the user matching the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The photos or profile URL of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.urls.lookupUser.html</cref>
        /// </see>
        public IHttpResponse LookupUser(string url) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return Client.Get("https://api.flickr.com/services/rest", new HttpQueryString {
                {"method", "flickr.urls.lookupUser"},
                {"url", url}
            });
        }

        #endregion

    }

}