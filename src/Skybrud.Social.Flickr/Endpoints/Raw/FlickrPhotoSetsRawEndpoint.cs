using System;
using System.Collections.Specialized;
using Skybrud.Social.Flickr.OAuth;
using Skybrud.Social.Flickr.Options.Photosets;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Endpoints.Raw {
    
    public class FlickrPhotosetsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr OAuth client.
        /// </summary>
        public FlickrOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public FlickrPhotosetsRawEndpoint(FlickrOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods
        
        /// <summary>
        /// Gets information about the photoset with the specified <code>photosetId</code>.
        /// </summary>
        /// <param name="photosetId">The ID of the photoset.</param>
        /// <param name="userId">The ID of the owner of the photoset. This is optional, but according to the Flickr API
        /// documentation, this gives better performance.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photosets.getInfo.html</cref>
        /// </see>
        public SocialHttpResponse GetInfo(string photosetId, string userId = null) {
            
            // A bit of input validation
            if (String.IsNullOrWhiteSpace(photosetId)) throw new ArgumentNullException("photosetId");

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"method", "flickr.photosets.getInfo"},
                {"photoset_id", photosetId}
            };

            // Append the user ID (if specified)
            if (!String.IsNullOrWhiteSpace(userId)) query.Add("user_id", userId);

            // Make the call to the API
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", query);
        
        }

        /// <summary>
        /// Gets a list of the photosets of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photosets.getList.html</cref>
        /// </see>
        public SocialHttpResponse GetList(string userId) {
            if (String.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException("userId");
            return GetList(new FlickrGetPhotosetsOptions(userId));
        }

        /// <summary>
        /// Gets a list of the photosets matching the specified <code>options</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="page">The page to be returned..</param>
        /// <param name="perPage">The maximum amount of photosets to be returned per page.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photosets.getList.html</cref>
        /// </see>
        public SocialHttpResponse GetList(string userId, int page, int perPage) {
            if (String.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException("userId");
            return GetList(new FlickrGetPhotosetsOptions(userId, page, perPage));
        }

        /// <summary>
        /// Gets a list of the photosets matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photosets.getList.html</cref>
        /// </see>
        public SocialHttpResponse GetList(FlickrGetPhotosetsOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", options);
        }

        #endregion

    }

}