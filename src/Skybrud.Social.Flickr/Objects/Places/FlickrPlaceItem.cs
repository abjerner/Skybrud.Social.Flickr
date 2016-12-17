using System.Xml.Linq;
using Skybrud.Essentials.Locations;
using Skybrud.Essentials.Xml.Extensions;
using Skybrud.Social.Flickr.Enums;

namespace Skybrud.Social.Flickr.Objects.Places {
    
    /// <summary>
    /// Class representing a place.
    /// </summary>
    public class FlickrPlaceItem : FlickrObject, ILocation {

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

        /// <summary>
        /// Gets the type of the place.
        /// </summary>
        public FlickrPlaceType PlaceType { get; private set; }

        /// <summary>
        /// Gets the ID of the type of the place.
        /// </summary>
        public int PlaceTypeId { get; private set; }

        /// <summary>
        /// Gets the name of the timezone of the place - eg. <code>Europe/London</code> or
        /// <code>Europe/Copenhagen</code>.
        /// </summary>
        public string Timezone { get; private set; }

        /// <summary>
        /// Gets Where On Earth (WOE) name of the place.
        /// </summary>
        public string WoeName { get; private set; }

        /// <summary>
        /// Gets the name of the place.
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPlaceItem(XElement xml) : base(xml) {

            // Parse the attributes
            Id = xml.GetAttributeValue("place_id");
            WoeId = xml.GetAttributeValue("woeid");
            Latitude = xml.GetAttributeValue<double>("latitude");
            Longitude = xml.GetAttributeValue<double>("longitude");
            PlaceUrl = xml.GetAttributeValue("place_url");
            PlaceType = xml.GetAttributeValueAsEnum<FlickrPlaceType>("place_type");
            PlaceTypeId = xml.GetAttributeValue<int>("place_type_id");
            Timezone = xml.GetAttributeValue("timezone");
            WoeName = xml.GetAttributeValue("woe_name");
            
            // Get the name from the inner text
            Name = xml.Value;
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPlaceItem"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPlaceItem Parse(XElement xml) {
            return xml == null ? null : new FlickrPlaceItem(xml);
        }

        #endregion

    }

}