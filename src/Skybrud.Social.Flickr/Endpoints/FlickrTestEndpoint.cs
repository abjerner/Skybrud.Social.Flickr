using Skybrud.Social.Flickr.Endpoints.Raw;

namespace Skybrud.Social.Flickr.Endpoints {
    
    public class FlickrTestEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr service.
        /// </summary>
        public FlickrService Service { get; private set; }
        
        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FlickrTestRawEndpoint Raw {
            get { return Service.Client.Test; }
        }

        #endregion

        #region Constructors

        public FlickrTestEndpoint(FlickrService service) {
            Service = service;
        }

        #endregion

        #region Member methods


        #endregion

    }

}