using System;
using System.Collections.Specialized;
using Skybrud.Social.Flickr.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the groups Flickr endpoint.
    /// </summary>
    public class FlickrGroupsRawEndpoint {

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
        internal FlickrGroupsRawEndpoint(FlickrOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the group with the specified <code>groupId</code>.
        /// </summary>
        /// <param name="groupId">The ID of the group to fetch information about.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.groups.getInfo.html</cref>
        /// </see>
        public SocialHttpResponse GetInfo(string groupId) {
            if (String.IsNullOrWhiteSpace(groupId)) throw new ArgumentNullException("url");

            throw new NotImplementedException();

            //return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new NameValueCollection {
            //    {"method", "flickr.groups.getInfo"},
            //    {"url", url}
            //});
        }

        #endregion

    }

}