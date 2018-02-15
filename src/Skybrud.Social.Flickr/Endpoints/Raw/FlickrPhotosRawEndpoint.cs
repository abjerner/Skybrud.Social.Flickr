using System;
using System.Collections.Specialized;
using Skybrud.Social.Flickr.OAuth;
using Skybrud.Social.Flickr.Options.Photos;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Photos</strong> Flickr endpoint.
    /// </summary>
    public class FlickrPhotosRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr OAuth client.
        /// </summary>
        public FlickrOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FlickrPhotosRawEndpoint(FlickrOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the photo with the specified <paramref name="photoId"/>. The authenticated user must
        /// have permission to view the photo.
        /// </summary>
        /// <param name="photoId">The ID of the photo.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photos.getInfo.html</cref>
        /// </see>
        public SocialHttpResponse GetInfo(string photoId) {
            if (String.IsNullOrWhiteSpace(photoId)) throw new ArgumentNullException(nameof(photoId));
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new SocialHttpQueryString {
                {"method", "flickr.photos.getInfo"},
                {"photo_id", photoId},
                {"username", photoId}
            });
        }

        /// <summary>
        /// Uploads a photo as described by the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/upload.api.html</cref>
        /// </see>
        public SocialHttpResponse Upload(FlickrUploadPhotoOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpPostRequest("https://up.flickr.com/services/upload/", options);
        }

        #endregion

    }

}