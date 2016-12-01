using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Places {
    
    /// <summary>
    /// Class representing a place.
    /// </summary>
    public class FlickrPlaceItem : FlickrObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the place.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets Where On Earth (WOE) ID of the place.
        /// </summary>
        public string WoeId { get; private set; }

        /// <summary>
        /// Gets the name of the place.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the latitude of the place.
        /// </summary>
        public double Latitude { get; private set; }

        /// <summary>
        /// Gets the longitude of the place.
        /// </summary>
        public double Longitude { get; private set; }

        /// <summary>
        /// Gets the Flickr URL of the place.
        /// </summary>
        public string PlaceUrl { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPlaceItem(XElement xml) : base(xml) {
            Id = xml.GetAttributeValue("place_id");
            WoeId = xml.GetAttributeValue("woeid");
            Name = xml.Value;
            Latitude = xml.GetAttributeValue<double>("latitude");
            Longitude = xml.GetAttributeValue<double>("longitude");
            PlaceUrl = xml.GetAttributeValue("place_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPlaceItem"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPlaceItem Parse(XElement xml) {
            return xml == null ? null : new FlickrPlaceItem(xml);
        }

        #endregion

    }

}