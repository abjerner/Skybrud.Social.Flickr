using Skybrud.Social.Flickr.Endpoints.Raw;
using Skybrud.Social.Flickr.Responses.People;

namespace Skybrud.Social.Flickr.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>People</strong> Flickr endpoint.
    /// </summary>
    public class FlickrPeopleEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr service.
        /// </summary>
        public FlickrService Service { get; }
        
        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FlickrPeopleRawEndpoint Raw => Service.Client.People;

        #endregion

        #region Constructors

        internal FlickrPeopleEndpoint(FlickrService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user to lookup.</param>
        /// <returns>An instance of <see cref="FlickrFindByUsernameResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.people.findByUsername.html</cref>
        /// </see>
        public FlickrFindByUsernameResponse FindByUsername(string username) {
            return FlickrFindByUsernameResponse.ParseResponse(Raw.FindByUsername(username));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user to fetch information about.</param>
        /// <returns>An instance of <see cref="FlickrGetPersonResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.people.getInfo.html</cref>
        /// </see>
        public FlickrGetPersonResponse GetInfo(string userId) {
            return FlickrGetPersonResponse.ParseResponse(Raw.GetInfo(userId));
        }

        #endregion

    }

}