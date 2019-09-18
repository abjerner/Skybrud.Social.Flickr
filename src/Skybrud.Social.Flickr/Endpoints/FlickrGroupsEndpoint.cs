using Skybrud.Social.Flickr.Endpoints.Groups;
using Skybrud.Social.Flickr.Endpoints.Raw;

namespace Skybrud.Social.Flickr.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Groups</strong> Flickr endpoint.
    /// </summary>
    public class FlickrGroupsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr service.
        /// </summary>
        public FlickrService Service { get; }
        
        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FlickrGroupsRawEndpoint Raw => Service.Client.Groups;

        public FlickrGroupsPoolsEndpoint Pools { get; }

        #endregion

        #region Constructors

        internal FlickrGroupsEndpoint(FlickrService service) {
            Service = service;
            Pools = new FlickrGroupsPoolsEndpoint(service);
        }

        #endregion

    }

}