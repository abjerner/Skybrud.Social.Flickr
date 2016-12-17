using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Places {

    /// <summary>
    /// Class representing the response body as returned by the <code>flickr.places.find</code> API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.places.find.html</cref>
    /// </see>
    public class FlickrPlacesFindResponseBody : FlickrResponseBody {

        #region Properties

        /// <summary>
        /// Gets a reference to a collection of the places matching the query as specified in the request to the
        /// <code>flickr.places.find</code> API method.
        /// </summary>
        public FlickrPlacesFindCollection Places { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <see cref="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPlacesFindResponseBody(XElement xml) : base(xml) {
            Places = xml.GetElement("places", FlickrPlacesFindCollection.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPlacesFindResponseBody"/> from the specified <see cref="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPlacesFindResponseBody Parse(XElement xml) {
            return xml == null ? null : new FlickrPlacesFindResponseBody(xml);
        }

        #endregion

    }

}