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
        /// Gets the latitude of the place.
        /// </summary>
        public double Latitude { get; private set; }

        /// <summary>
        /// Gets the longitude of the place.
        /// </summary>
        public double Longitude { get; private set; }

        /// <summary>
        /// Gets the accuracy of the place.
        /// </summary>
        public int Accuracy { get; private set; }

        // TODO: Implement property for the "context" attribute

        /// <summary>
        /// Gets the ID of the place.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets Where On Earth (WOE) ID of the place.
        /// </summary>
        public string WoeId { get; private set; }

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

        /// <summary>
        /// Gets the name of the place.
        /// </summary>
        public string Name {
            get {
                if (HasNeighbourhood) return Neighbourhood.Name;
                if (HasLocality) return Locality.Name;
                if (HasCounty) return County.Name;
                if (HasRegion) return Region.Name;
                if (HasCountry) return Country.Name;
                return null;
            }
        }

        /// <summary>
        /// Gets the type of the place.
        /// </summary>
        public FlickrPlaceType Type {
            get {
                if (HasNeighbourhood) return FlickrPlaceType.Neighbourhood;
                if (HasLocality) return FlickrPlaceType.Locality;
                if (HasCounty) return FlickrPlaceType.County;
                if (HasRegion) return FlickrPlaceType.Region;
                if (HasCountry) return FlickrPlaceType.County;
                return FlickrPlaceType.Unknown;
            }
        }

        public string PlaceType { get; private set; }
        public int PlaceTypeId { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPlace(XElement xml) : base(xml) {
            Latitude = xml.GetAttributeValue<double>("latitude");
            Longitude = xml.GetAttributeValue<double>("longitude");
            Accuracy = xml.GetAttributeValue<int>("accuracy");
            Id = xml.GetAttributeValue("place_id");
            WoeId = xml.GetAttributeValue("woeid");
            Neighbourhood = xml.GetElement("neighbourhood", FlickrPlaceItem.Parse);
            Locality = xml.GetElement("locality", FlickrPlaceItem.Parse);
            County = xml.GetElement("county", FlickrPlaceItem.Parse);
            Region = xml.GetElement("region", FlickrPlaceItem.Parse);
            Country = xml.GetElement("country", FlickrPlaceItem.Parse);
            PlaceType = xml.GetAttributeValue("place_type");
            PlaceTypeId = xml.GetAttributeValue<int>("place_type_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPlace"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPlace Parse(XElement xml) {
            return xml == null ? null : new FlickrPlace(xml);
        }

        #endregion

    }

}