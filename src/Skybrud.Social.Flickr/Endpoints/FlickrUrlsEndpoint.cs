using Skybrud.Social.Flickr.Endpoints.Raw;
using Skybrud.Social.Flickr.Responses.Urls;

namespace Skybrud.Social.Flickr.Endpoints {

    /// <summary>
    /// Class representing the implementation of the URLs Flickr endpoint.
    /// </summary>
    public class FlickrUrlsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr service.
        /// </summary>
        public FlickrService Service { get; }
        
        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FlickrUrlsRawEndpoint Raw => Service.Client.Urls;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instanc based on the specified <paramref name="service"/>.
        /// </summary>
        /// <param name="service">An instance of <see cref="FlickrService"/> representing the parent service.</param>
        internal FlickrUrlsEndpoint(FlickrService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Return the Flickr ID of the user matching the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The photos or profile URL of the user.</param>
        /// <returns>An instance of <see cref="FlickrUrlsLookupUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.urls.lookupUser.html</cref>
        /// </see>
        public FlickrUrlsLookupUserResponse LookupUser(string url) {
            return FlickrUrlsLookupUserResponse.ParseResponse(Raw.LookupUser(url));
        }

        #endregion

    }

}