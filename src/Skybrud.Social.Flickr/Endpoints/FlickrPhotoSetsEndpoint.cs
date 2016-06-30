using Skybrud.Social.Flickr.Endpoints.Raw;
using Skybrud.Social.Flickr.Options.Photosets;
using Skybrud.Social.Flickr.Responses.Photosets;

namespace Skybrud.Social.Flickr.Endpoints {
    
    public class FlickrPhotosetsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr service.
        /// </summary>
        public FlickrService Service { get; private set; }
        
        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FlickrPhotosetsRawEndpoint Raw {
            get { return Service.Client.Photosets; }
        }

        #endregion

        #region Constructors

        public FlickrPhotosetsEndpoint(FlickrService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the photoset with the specified <code>photosetId</code>.
        /// </summary>
        /// <param name="photosetId">The ID of the photoset.</param>
        /// <param name="userId">The ID of the owner of the photoset. This is optional, but according to the Flickr API
        /// documentation, this gives better performance.</param>
        /// <returns>Returns an instance of <see cref="FlickrGetPhotosetInfoResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photosets.getInfo.html</cref>
        /// </see>
        public FlickrGetPhotosetInfoResponse GetInfo(string photosetId, string userId = null) {
            return FlickrGetPhotosetInfoResponse.ParseResponse(Raw.GetInfo(photosetId, userId));
        }

        /// <summary>
        /// Gets a list of the photosets of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>Returns an instance of <see cref="FlickrGetPhotosetListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photosets.getList.html</cref>
        /// </see>
        public FlickrGetPhotosetListResponse GetList(string userId) {
            return FlickrGetPhotosetListResponse.ParseResponse(Raw.GetList(userId));
        }

        /// <summary>
        /// Gets a list of the photosets matching the specified <code>options</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="page">The page to be returned..</param>
        /// <param name="perPage">The maximum amount of photosets to be returned per page.</param>
        /// <returns>Returns an instance of <see cref="FlickrGetPhotosetListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photosets.getList.html</cref>
        /// </see>
        public FlickrGetPhotosetListResponse GetList(string userId, int page, int perPage) {
            return FlickrGetPhotosetListResponse.ParseResponse(Raw.GetList(userId, page, perPage));
        }

        /// <summary>
        /// Gets a list of the photosets matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <see cref="FlickrGetPhotosetListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.photosets.getList.html</cref>
        /// </see>
        public FlickrGetPhotosetListResponse GetList(FlickrGetPhotosetsOptions options) {
            return FlickrGetPhotosetListResponse.ParseResponse(Raw.GetList(options));
        }

        #endregion

    }

}