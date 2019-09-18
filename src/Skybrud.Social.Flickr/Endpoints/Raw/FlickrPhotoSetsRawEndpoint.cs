using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Flickr.OAuth;
using Skybrud.Social.Flickr.Options.Photosets;

namespace Skybrud.Social.Flickr.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Photosets</strong> Flickr endpoint.
    /// </summary>
    public class FlickrPhotosetsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr OAuth client.
        /// </summary>
        public FlickrOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal FlickrPhotosetsRawEndpoint(FlickrOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the photoset with the specified <paramref name="photosetId"/>.
        /// </summary>
        /// <param name="photosetId">The ID of the photoset.</param>
        /// <param name="userId">The ID of the owner of the photoset. This is optional, but according to the Flickr API
        /// documentation, this gives better performance.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photosets.getInfo.html</cref>
        /// </see>
        public IHttpResponse GetInfo(string photosetId, string userId = null) {
            
            // A bit of input validation
            if (string.IsNullOrWhiteSpace(photosetId)) throw new ArgumentNullException(nameof(photosetId));

            // Initialize the query string
            HttpQueryString query = new HttpQueryString {
                {"method", "flickr.photosets.getInfo"},
                {"photoset_id", photosetId}
            };

            // Append the user ID (if specified)
            if (!string.IsNullOrWhiteSpace(userId)) query.Add("user_id", userId);

            // Make the call to the API
            return Client.Get("https://api.flickr.com/services/rest", query);
        
        }

        /// <summary>
        /// Gets a list of the photosets of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photosets.getList.html</cref>
        /// </see>
        public IHttpResponse GetList(string userId) {
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException(nameof(userId));
            return GetList(new FlickrGetPhotosetsOptions(userId));
        }

        /// <summary>
        /// Gets a list of the photosets of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="page">The page to be returned..</param>
        /// <param name="perPage">The maximum amount of photosets to be returned per page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photosets.getList.html</cref>
        /// </see>
        public IHttpResponse GetList(string userId, int page, int perPage) {
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException(nameof(userId));
            return GetList(new FlickrGetPhotosetsOptions(userId, page, perPage));
        }

        /// <summary>
        /// Gets a list of the photosets matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photosets.getList.html</cref>
        /// </see>
        public IHttpResponse GetList(FlickrGetPhotosetsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.Get("https://api.flickr.com/services/rest", options);
        }

        #endregion

    }

}