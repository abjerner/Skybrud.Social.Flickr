using Skybrud.Social.Flickr.Endpoints.Raw;

namespace Skybrud.Social.Flickr.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Test</strong> Flickr endpoint.
    /// </summary>
    public class FlickrTestEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr service.
        /// </summary>
        public FlickrService Service { get; }
        
        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FlickrTestRawEndpoint Raw => Service.Client.Test;

        #endregion

        #region Constructors

        internal FlickrTestEndpoint(FlickrService service) {
            Service = service;
        }

        #endregion

        #region Member methods


        #endregion

    }

}