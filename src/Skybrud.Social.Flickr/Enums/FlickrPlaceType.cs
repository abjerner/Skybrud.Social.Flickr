namespace Skybrud.Social.Flickr.Enums {
    
    /// <summary>
    /// Enum class indicating the type of place.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.places.getPlaceTypes.html</cref>
    /// </see>
    public enum FlickrPlaceType {

        /// <summary>
        /// Indicates that the type of the place is not known - eg. if the latitude and longitude hasn't been mapped to
        /// an actual location.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Indicates that the place is a neighbourhood.
        /// </summary>
        Neighbourhood = 22,

        /// <summary>
        /// Indicates that the place is a locality (typically a city or town).
        /// </summary>
        Locality = 7,

        /// <summary>
        /// Indicates that the place is a county. This value also appears to be used for municipalities in some
        /// countries - eg. Denmark.
        /// </summary>
        County = 9,

        /// <summary>
        /// Indicates the region of the place - eg. <code>California</code>.
        /// </summary>
        Region = 8,

        /// <summary>
        /// Indicates the country of the place - eg. <code>Denmark</code> or <code>United States</code>.
        /// </summary>
        Country = 12,

        /// <summary>
        /// Indicates the continent of the place (<em>I haven't yet seen this value used</em>).
        /// </summary>
        Continent = 29

    }

}