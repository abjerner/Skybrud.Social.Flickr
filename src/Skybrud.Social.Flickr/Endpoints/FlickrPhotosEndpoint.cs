using Skybrud.Social.Flickr.Endpoints.Raw;
using Skybrud.Social.Flickr.Options.Photos;
using Skybrud.Social.Flickr.Responses.Photos;

namespace Skybrud.Social.Flickr.Endpoints {
    
    public class FlickrPhotosEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr service.
        /// </summary>
        public FlickrService Service { get; private set; }
        
        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FlickrPhotosRawEndpoint Raw {
            get { return Service.Client.Photos; }
        }

        #endregion

        #region Constructors

        public FlickrPhotosEndpoint(FlickrService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the photo with the specified <code>photoId</code>. The authenticated user must have permission to view the photo.
        /// </summary>
        /// <param name="photoId">The ID of the photo.</param>
        /// <returns>Returns an instance of <see cref="FlickrGetPhotoInfoResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photos.getInfo.html</cref>
        /// </see>
        public FlickrGetPhotoInfoResponse GetInfo(string photoId) {
            return FlickrGetPhotoInfoResponse.ParseResponse(Raw.GetInfo(photoId));
        }

        /// <summary>
        /// Uploads a photo as described by the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <see cref="FlickrUploadPhotoResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/upload.api.html</cref>
        /// </see>
        public FlickrUploadPhotoResponse Upload(FlickrUploadPhotoOptions options) {
            return FlickrUploadPhotoResponse.ParseResponse(Raw.Upload(options));
        }

        #endregion

    }

}