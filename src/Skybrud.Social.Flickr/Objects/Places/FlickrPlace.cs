using System.Xml.Linq;
using Skybrud.Essentials.Locations;
using Skybrud.Essentials.Xml.Extensions;
using Skybrud.Social.Flickr.Enums;

namespace Skybrud.Social.Flickr.Objects.Places {

    /// <summary>
    /// Class representing a place.
    /// </summary>
    public class FlickrPlace : FlickrObject, ILocation {

        #region Properties

        /// <summary>
        /// Gets the ID of the place.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets <strong>Where On Earth (WOE)</strong> ID of the place.
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
        /// Gets the internal Flickr URL of the place.
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
        /// Gets the name of the place.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the name of the <strong>Where On Earth (WOE)</strong> of the place.
        /// </summary>
        public string WoeName { get; private set; }

        /// <summary>
        /// Gets whether any shape data is available for the place.
        /// </summary>
        public bool HasShapeData { get; private set; }

        /// <summary>
        /// Gets a reference to the neighbourhood of the place.
        /// </summary>
        public FlickrPlaceItem Neighbourhood { get; private set; }

        /// <summary>
        /// Gets whether a neighbourhood has been specified for the place.
        /// </summary>
        public bool HasNeighbourhood {
            get { return Neighbourhood != null; }
        }

        /// <summary>
        /// Gets a reference to the locality of the place.
        /// </summary>
        public FlickrPlaceItem Locality { get; private set; }

        /// <summary>
        /// Gets whether a locality has been specified for the place.
        /// </summary>
        public bool HasLocality {
            get { return Locality != null; }
        }

        /// <summary>
        /// Gets a reference to the county of the place.
        /// </summary>
        public FlickrPlaceItem County { get; private set; }

        /// <summary>
        /// Gets whether a county has been specified for the place.
        /// </summary>
        public bool HasCounty {
            get { return County != null; }
        }

        /// <summary>
        /// Gets a reference to the region of the place.
        /// </summary>
        public FlickrPlaceItem Region { get; private set; }

        /// <summary>
        /// Gets whether a region has been specified for the place.
        /// </summary>
        public bool HasRegion {
            get { return Region != null; }
        }

        /// <summary>
        /// Gets a reference to the country of the place.
        /// </summary>
        public FlickrPlaceItem Country { get; private set; }

        /// <summary>
        /// Gets whether a country has been specified for the place.
        /// </summary>
        public bool HasCountry {
            get { return Country != null; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPlace(XElement xml) : base(xml) {
            
            // Attributes
            Id = xml.GetAttributeValue("place_id");
            WoeId = xml.GetAttributeValue("woeid");
            Latitude = xml.GetAttributeValue<double>("latitude");
            Longitude = xml.GetAttributeValue<double>("longitude");
            PlaceUrl = xml.GetAttributeValue("place_url");
            PlaceType = xml.GetAttributeValueAsEnum<FlickrPlaceType>("place_type");
            PlaceTypeId = xml.GetAttributeValue<int>("place_type_id");
            Timezone = xml.GetAttributeValue("timezone");
            Name = xml.GetAttributeValue("name");
            WoeName = xml.GetAttributeValue("woe_name");
            HasShapeData = xml.GetAttributeValueAsBoolean("has_shapedata");

            // Elements
            Neighbourhood = xml.GetElement("neighbourhood", FlickrPlaceItem.Parse);
            Locality = xml.GetElement("locality", FlickrPlaceItem.Parse);
            County = xml.GetElement("county", FlickrPlaceItem.Parse);
            Region = xml.GetElement("region", FlickrPlaceItem.Parse);
            Country = xml.GetElement("country", FlickrPlaceItem.Parse);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPlace"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPlace Parse(XElement xml) {
            return xml == null ? null : new FlickrPlace(xml);
        }

        #endregion

    }

}