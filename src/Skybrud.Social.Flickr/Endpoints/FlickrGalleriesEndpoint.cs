using Skybrud.Social.Flickr.Endpoints.Raw;

namespace Skybrud.Social.Flickr.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Galleries</strong> Flickr endpoint.
    /// </summary>
    public class FlickrGalleriesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr service.
        /// </summary>
        public FlickrService Service { get; }
        
        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FlickrGalleriesRawEndpoint Raw => Service.Client.Galleries;

        #endregion

        #region Constructors

        internal FlickrGalleriesEndpoint(FlickrService service) {
            Service = service;
        }

        #endregion

        #region Member methods


        #endregion

    }

}