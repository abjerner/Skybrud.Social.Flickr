using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Places {

    /// <summary>
    /// Class representing the response body as returned by the <code>flickr.places.getInfo</code> API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.places.getInfo.html</cref>
    /// </see>
    public class FlickrPlacesGetInfoResponseBody : FlickrResponseBody {

        #region Properties

        /// <summary>
        /// Gets a reference to an instance of <see cref="FlickrPlace"/> with information about the place.
        /// </summary>
        public FlickrPlace Place { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPlacesGetInfoResponseBody(XElement xml) : base(xml) {
            Place = xml.GetElement("place", FlickrPlace.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPlacesGetInfoResponseBody"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPlacesGetInfoResponseBody Parse(XElement xml) {
            return xml == null ? null : new FlickrPlacesGetInfoResponseBody(xml);
        }

        #endregion

    }

}