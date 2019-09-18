using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Flickr.OAuth;
using Skybrud.Social.Flickr.Options.Groups.Pools;

namespace Skybrud.Social.Flickr.Endpoints.Raw.Groups {

    public class FlickrGroupsPoolsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr OAuth client.
        /// </summary>
        public FlickrOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instanced based on the <paramref name="client"/>.
        /// </summary>
        /// <param name="client">An instance of <see cref="FlickrOAuthClient"/> representing the parent OAuth client.</param>
        internal FlickrGroupsPoolsRawEndpoint(FlickrOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a list of pool photos for a given group, based on the permissions of the group and the user logged in (if any).
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.groups.pools.getPhotos.html</cref>
        /// </see>
        public IHttpResponse GetPhotos(FlickrGroupsPoolsGetPhotosOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.Get("https://api.flickr.com/services/rest", options);
        }

        #endregion

    }

}