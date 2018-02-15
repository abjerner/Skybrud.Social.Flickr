using System.Collections.Specialized;
using Skybrud.Social.Flickr.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Endpoints.Raw {
    
    public class FlickrTestRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr OAuth client.
        /// </summary>
        public FlickrOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public FlickrTestRawEndpoint(FlickrOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// A testing method which checks if the caller is logged in then returns their username. Requires the <code>read</code> permission/scope.
        /// </summary>
        /// <returns>Returns the username of the authenticated user.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.test.login.html</cref>
        /// </see>
        public SocialHttpResponse Login() {
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new SocialHttpQueryString {
                {"method", "flickr.test.login"},
            });
        }

        #endregion

    }

}