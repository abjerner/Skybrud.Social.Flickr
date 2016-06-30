using System;
using System.Collections.Specialized;
using Skybrud.Social.Flickr.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Endpoints.Raw {
    
    public class FlickrGalleriesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr OAuth client.
        /// </summary>
        public FlickrOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public FlickrGalleriesRawEndpoint(FlickrOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of galleries created by the user with the specified <code>userId</code>. Sorted from newest to oldest.
        /// </summary>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.galleries.getList.html</cref>
        /// </see>
        public SocialHttpResponse GetList(string userId) {
            if (String.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException("userId");
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new NameValueCollection {
                {"method", "flickr.galleries.getList"},
                {"user_id", userId}
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.galleries.create.html</cref>
        /// </see>
        public SocialHttpResponse Create(string title, string description) {
            if (String.IsNullOrWhiteSpace(title)) throw new ArgumentNullException("title");
            return Client.DoHttpRequest(
                SocialHttpMethod.Post,
                "https://api.flickr.com/services/rest",
                new NameValueCollection {
                    {"method", "flickr.galleries.create"},
                },
                new NameValueCollection {
                    {"title", title},
                    {"description", description}
                }
            );
        }

        #endregion

    }

}