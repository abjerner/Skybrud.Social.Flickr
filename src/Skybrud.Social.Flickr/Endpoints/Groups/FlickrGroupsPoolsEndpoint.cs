using Skybrud.Social.Flickr.Endpoints.Raw.Groups;
using Skybrud.Social.Flickr.Options.Groups.Pools;
using Skybrud.Social.Flickr.Responses.Groups;

namespace Skybrud.Social.Flickr.Endpoints.Groups {

    public class FlickrGroupsPoolsEndpoint {

        #region Properties

        public FlickrService Service { get; }

        public FlickrGroupsPoolsRawEndpoint Raw => Service.Client.Groups.Pools;

        #endregion

        #region Constructors

        internal FlickrGroupsPoolsEndpoint(FlickrService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a list of pool photos for a given group, based on the permissions of the group and the user logged in (if any).
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="FlickrGetPhotoListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.groups.pools.getPhotos.html</cref>
        /// </see>
        public FlickrGetPhotoListResponse GetPhotos(FlickrGroupsPoolsGetPhotosOptions options) {
            return FlickrGetPhotoListResponse.ParseResponse(Raw.GetPhotos(options));
        }

        #endregion

    }

}