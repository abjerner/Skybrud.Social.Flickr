using Skybrud.Social.Flickr.Endpoints.Raw;
using Skybrud.Social.Flickr.Options.Photos;
using Skybrud.Social.Flickr.Responses.Photos;

namespace Skybrud.Social.Flickr.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Photos</strong> Flickr endpoint.
    /// </summary>
    public class FlickrPhotosEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr service.
        /// </summary>
        public FlickrService Service { get; }
        
        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FlickrPhotosRawEndpoint Raw => Service.Client.Photos;

        #endregion

        #region Constructors

        internal FlickrPhotosEndpoint(FlickrService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the photo with the specified <paramref name="photoId"/>. The authenticated user must
        /// have permission to view the photo.
        /// </summary>
        /// <param name="photoId">The ID of the photo.</param>
        /// <returns>An instance of <see cref="FlickrGetPhotoInfoResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photos.getInfo.html</cref>
        /// </see>
        public FlickrGetPhotoInfoResponse GetInfo(string photoId) {
            return FlickrGetPhotoInfoResponse.ParseResponse(Raw.GetInfo(photoId));
        }

        /// <summary>
        /// Uploads a photo as described by the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="FlickrUploadPhotoResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/upload.api.html</cref>
        /// </see>
        public FlickrUploadPhotoResponse Upload(FlickrUploadPhotoOptions options) {
            return FlickrUploadPhotoResponse.ParseResponse(Raw.Upload(options));
        }

        #endregion

    }

}