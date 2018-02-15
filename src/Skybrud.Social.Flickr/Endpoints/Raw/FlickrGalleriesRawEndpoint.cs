using System;
using Skybrud.Social.Flickr.OAuth;
using Skybrud.Social.Flickr.Options.Galleries;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Galleries</strong> Flickr endpoint.
    /// </summary>
    public class FlickrGalleriesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr OAuth client.
        /// </summary>
        public FlickrOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FlickrGalleriesRawEndpoint(FlickrOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Creates a new gallery with the specified <paramref name="title"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="title">The title of the gallery.</param>
        /// <param name="description">The description of the gallery.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.galleries.create.html</cref>
        /// </see>
        public SocialHttpResponse Create(string title, string description) {
            if (String.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title));
            if (String.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            return Create(new FlickrCreateGalleryOptions(title, description));
        }

        /// <summary>
        /// Creates a new gallery with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.galleries.create.html</cref>
        /// </see>
        public SocialHttpResponse Create(FlickrCreateGalleryOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", options);
        }

        /// <summary>
        /// Gets information about the gallery with the specified <code>galleryId</code>.
        /// </summary>
        /// <param name="galleryId">The ID of the gallery to fetch information about.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.galleries.getInfo.html</cref>
        /// </see>
        public SocialHttpResponse GetInfo(string galleryId) {
            if (String.IsNullOrWhiteSpace(galleryId)) throw new ArgumentNullException(nameof(galleryId));
            return GetInfo(new FlickrGetGalleryInfoOptions(galleryId));
        }

        /// <summary>
        /// Gets information about the gallery matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.galleries.getInfo.html</cref>
        /// </see>
        public SocialHttpResponse GetInfo(FlickrGetGalleryInfoOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", options);
        }

        /// <summary>
        /// Gets a list of galleries created by the user with the specified <code>userId</code>. Sorted from newest to
        /// oldest.
        /// </summary>
        /// <param name="userId">The ID of the user to get a galleries list for. If none is specified, the calling user
        /// is assumed.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.galleries.getList.html</cref>
        /// </see>
        public SocialHttpResponse GetList(string userId) {
            if (String.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException(nameof(userId));
            return GetList(new FlickrGetGalleryListOptions(userId));
        }

        /// <summary>
        /// Gets a list of galleries created by the user matching the specified <paramref name="options"/>. Sorted from
        /// newest to oldest.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.galleries.getList.html</cref>
        /// </see>
        public SocialHttpResponse GetList(FlickrGetGalleryListOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", options);
        }

        #endregion

    }

}