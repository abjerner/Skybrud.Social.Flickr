using System;
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
        public string Id { get; }

        /// <summary>
        /// Gets Where On Earth (WOE) ID of the place.
        /// </summary>
        public string WoeId { get; }

        /// <summary>
        /// Gets the latitude of the place.
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// Gets the longitude of the place.
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        /// Gets the Flickr URL of the place.
        /// </summary>
        public string PlaceUrl { get; }

        /// <summary>
        /// Gets the type of the place.
        /// </summary>
        public FlickrPlaceType PlaceType { get; }

        /// <summary>
        /// Gets the ID of the type of the place.
        /// </summary>
        public int PlaceTypeId { get; private set; }

        /// <summary>
        /// Gets the name of the timezone of the place - eg. <c>Europe/London</c> or
        /// <c>Europe/Copenhagen</c>.
        /// </summary>
        public string Timezone { get; }

        /// <summary>
        /// Gets Where On Earth (WOE) name of the place.
        /// </summary>
        public string WoeName { get; }

        /// <summary>
        /// Gets the name of the place.
        /// </summary>
        public string Name { get; }

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
            Latitude = xml.GetAttributeValueAsDouble("latitude", out double latitude) ? latitude : 0;
            Longitude = xml.GetAttributeValueAsDouble("longitude", out double longitude) ? longitude : 0;
            PlaceUrl = xml.GetAttributeValue("place_url");
            PlaceType = xml.GetAttributeValueAsEnum("place_type", FlickrPlaceType.Unknown);
            PlaceTypeId = xml.GetAttributeValueAsInt32("place_type_id", out int placeTypeId) ? placeTypeId : 0;
            Timezone = xml.GetAttributeValue("timezone");
            WoeName = xml.GetAttributeValue("woe_name");

            // Get the name from the inner text
            Name = xml.Value;

            if (String.IsNullOrWhiteSpace(Name)) {
                Name = xml.GetAttributeValue("name");
            }
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPlaceItem"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrPlaceItem"/>.</returns>
        public static FlickrPlaceItem Parse(XElement xml) {
            return xml == null ? null : new FlickrPlaceItem(xml);
        }

        #endregion

    }

}