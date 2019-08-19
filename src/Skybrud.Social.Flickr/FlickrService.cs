using System;
using Skybrud.Essentials.Http.OAuth;
using Skybrud.Social.Flickr.Endpoints;
using Skybrud.Social.Flickr.OAuth;

namespace Skybrud.Social.Flickr {

    /// <summary>
    /// Class working as an entry point to the Flickr API.
    /// </summary>
    public class FlickrService {

        #region Properties
        
        /// <summary>
        /// Gets a reference to the OAuth client used for communicating with the Flickr API.
        /// </summary>
        public FlickrOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the galleries endpoint.
        /// </summary>
        public FlickrGalleriesEndpoint Galleries { get; }

        /// <summary>
        /// Gets a reference to the people endpoint.
        /// </summary>
        public FlickrPeopleEndpoint People { get; }

        /// <summary>
        /// Gets a reference to the photosets endpoint.
        /// </summary>
        public FlickrPhotosetsEndpoint Photosets { get; }

        /// <summary>
        /// Gets a reference to the photos endpoint.
        /// </summary>
        public FlickrPhotosEndpoint Photos { get; }

        /// <summary>
        /// Gets a reference to the places endpoint.
        /// </summary>
        public FlickrPlacesEndpoint Places { get; }

        /// <summary>
        /// Gets a reference to the test endpoint.
        /// </summary>
        public FlickrTestEndpoint Test { get; }

        /// <summary>
        /// Gets a reference to the URLs endpoint.
        /// </summary>
        public FlickrUrlsEndpoint Urls { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public FlickrService() : this(new FlickrOAuthClient()) { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The client.</param>
        protected FlickrService(FlickrOAuthClient client) {
            Client = client;
            Galleries = new FlickrGalleriesEndpoint(this);
            People = new FlickrPeopleEndpoint(this);
            Photosets = new FlickrPhotosetsEndpoint(this);
            Photos = new FlickrPhotosEndpoint(this);
            Places = new FlickrPlacesEndpoint(this);
            Test = new FlickrTestEndpoint(this);
            Urls = new FlickrUrlsEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a service instance based on the specified <paramref name="consumerKey"/> and
        /// <paramref name="consumerSecret"/>. This will create an API reference without a user context.
        /// </summary>
        /// <param name="consumerKey">The consumer key of your Flickr app.</param>
        /// <param name="consumerSecret">The consumer secret Flickr app.</param>
        /// <returns>An instance of <see cref="FlickrService"/>.</returns>
        public static FlickrService CreateFromConsumerKey(string consumerKey, string consumerSecret) {

            // Initialize a new OAuth client
            FlickrOAuthClient client = new FlickrOAuthClient(consumerKey, consumerSecret, null, null);

            // Initialize a new service instance
            return new FlickrService(client);
        
        }

        /// <summary>
        /// Initializes a service instance based on the specified <paramref name="consumerKey"/> and
        /// <paramref name="consumerSecret"/> as well as the <paramref name="accessToken"/> and
        /// <paramref name="accessTokenSecret"/> of the authenticated user.
        /// </summary>
        /// <param name="consumerKey">The consumer key of your Flickr app.</param>
        /// <param name="consumerSecret">The consumer secret Flickr app.</param>
        /// <param name="accessToken">The access token of the authenticated user.</param>
        /// <param name="accessTokenSecret">The acess token secret of the authenticated user.</param>
        /// <returns>An instance of <see cref="FlickrService"/>.</returns>
        public static FlickrService CreateFromAccessToken(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret) {

            // Initialize a new OAuth client
            FlickrOAuthClient client = new FlickrOAuthClient(consumerKey, consumerSecret, accessToken, accessTokenSecret);

            // Initialize a new service instance
            return new FlickrService(client);

        }

        /// <summary>
        /// Initialize a service reference based on the specified OAuth <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        /// <returns>An instance of <see cref="FlickrService"/>.</returns>
        public static FlickrService CreateFromOAuthClient(OAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return CreateFromAccessToken(client.ConsumerKey, client.ConsumerSecret, client.Token, client.TokenSecret);
        }

        #endregion

    }

}