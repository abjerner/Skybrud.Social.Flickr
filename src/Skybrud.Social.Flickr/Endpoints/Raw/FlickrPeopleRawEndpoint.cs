using System;
using System.Collections.Specialized;
using Skybrud.Social.Flickr.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Endpoints.Raw {
    
    public class FlickrPeopleRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr OAuth client.
        /// </summary>
        public FlickrOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public FlickrPeopleRawEndpoint(FlickrOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the user with the specified <code>username</code>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.people.findByUsername.html</cref>
        /// </see>
        public SocialHttpResponse FindByUsername(string username) {
            if (String.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username");
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new NameValueCollection {
                {"method", "flickr.people.findByUsername"},
                {"username", username}
            });
        }

        #endregion

    }

}