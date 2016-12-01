using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Places {
    
    public class FlickrPlacesFindByLatLonResponseBody : FlickrResponseBody {

        #region Properties

        public FlickrPlacesFindByLatLonCollection Places { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPlacesFindByLatLonResponseBody(XElement xml) : base(xml) {
            Places = xml.GetElement("places", FlickrPlacesFindByLatLonCollection.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPlacesFindByLatLonResponseBody"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPlacesFindByLatLonResponseBody Parse(XElement xml) {
            return xml == null ? null : new FlickrPlacesFindByLatLonResponseBody(xml);
        }

        #endregion

    }

}