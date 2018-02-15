using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;
using Skybrud.Social.Flickr.Models.People;

namespace Skybrud.Social.Flickr.Models.Urls {

    /// <summary>
    /// Class representing the response body as returned by the <c>flickr.urls.lookupUser</c> API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.urls.lookupUser.html</cref>
    /// </see>
    public class FlickrUrlsLookupUserResponseBody : FlickrResponseBody {

        #region Properties

        /// <summary>
        /// Gets a reference to an instance of <see cref="FlickrUser"/> with information about the user.
        /// </summary>
        public FlickrUser User { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrUrlsLookupUserResponseBody(XElement xml) : base(xml) {
            User = xml.GetElement("user", FlickrUser.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrUrlsLookupUserResponseBody"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrUrlsLookupUserResponseBody"/>.</returns>
        public static FlickrUrlsLookupUserResponseBody Parse(XElement xml) {
            return xml == null ? null : new FlickrUrlsLookupUserResponseBody(xml);
        }

        #endregion

    }

}