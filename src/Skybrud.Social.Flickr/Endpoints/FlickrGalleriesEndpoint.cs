using Skybrud.Social.Flickr.Endpoints.Raw;

namespace Skybrud.Social.Flickr.Endpoints {
    
    public class FlickrGalleriesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr service.
        /// </summary>
        public FlickrService Service { get; private set; }
        
        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FlickrGalleriesRawEndpoint Raw {
            get { return Service.Client.Galleries; }
        }

        #endregion

        #region Constructors

        public FlickrGalleriesEndpoint(FlickrService service) {
            Service = service;
        }

        #endregion

        #region Member methods


        #endregion

    }

}