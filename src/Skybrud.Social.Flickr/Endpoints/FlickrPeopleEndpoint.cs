using Skybrud.Social.Flickr.Endpoints.Raw;

namespace Skybrud.Social.Flickr.Endpoints {
    
    public class FlickrPeopleEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr service.
        /// </summary>
        public FlickrService Service { get; private set; }
        
        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FlickrPeopleRawEndpoint Raw {
            get { return Service.Client.People; }
        }

        #endregion

        #region Constructors

        public FlickrPeopleEndpoint(FlickrService service) {
            Service = service;
        }

        #endregion

        #region Member methods


        #endregion

    }

}