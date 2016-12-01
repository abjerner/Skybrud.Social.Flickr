using Skybrud.Social.Flickr.Endpoints.Raw;
using Skybrud.Social.Flickr.Responses.Places;

namespace Skybrud.Social.Flickr.Endpoints {
    
    public class FlickrPlacesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr service.
        /// </summary>
        public FlickrService Service { get; private set; }
        
        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FlickrPlacesRawEndpoint Raw {
            get { return Service.Client.Places; }
        }

        #endregion

        #region Constructors

        public FlickrPlacesEndpoint(FlickrService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the place with the specified <code>placeId</code>.
        /// </summary>
        /// <param name="placeId">The ID of the place to fetch information about.</param>
        /// <returns>Returns an instance of <see cref="FlickrPlacesGetInfoResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.places.getInfo.html</cref>
        /// </see>
        public FlickrPlacesGetInfoResponse GetInfo(string placeId) {
            return FlickrPlacesGetInfoResponse.ParseResponse(Raw.GetInfo(placeId));
        }

        /// <summary>
        /// Return a list of places matching the specified <code>query</code>.
        /// </summary>
        /// <param name="query">The query string to use for place ID lookups.</param>
        /// <returns>Returns an instance of <see cref="FlickrPlacesFindResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.places.find.htm</cref>
        /// </see>
        public FlickrPlacesFindResponse Find(string query) {
            return FlickrPlacesFindResponse.ParseResponse(Raw.Find(query));
        }

        /// <summary>
        /// Returns a place for the specified <code>latitude</code> and <code>longitude</code>.
        /// 
        /// The flickr.places.findByLatLon method is not meant to be a (reverse) geocoder in the traditional sense. It
        /// is designed to allow users to find photos for "places" and will round up to the nearest place type to which
        /// corresponding place IDs apply.
        /// 
        /// For example, if you pass it a street level coordinate it will return the city that contains the point
        /// rather than the street, or building, itself.
        /// 
        /// It will also truncate latitudes and longitudes to three decimal points.
        /// </summary>
        /// <param name="latitude">The latitude whose valid range is -90 to 90. Anything more than 4 decimal places
        /// will be truncated.</param>
        /// <param name="longitude">The longitude whose valid range is -180 to 180. Anything more than 4 decimal places
        /// will be truncated.</param>
        /// <returns>Returns an instance of <see cref="FlickrPlacesFindByLatLonResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.places.findByLatLon.htm</cref>
        /// </see>
        public FlickrPlacesFindByLatLonResponse FindByLatLon(double latitude, double longitude) {
            return FlickrPlacesFindByLatLonResponse.ParseResponse(Raw.FindByLatLon(latitude, longitude));
        }

        /// <summary>
        /// Returns a place for the specified <code>latitude</code> and <code>longitude</code>.
        /// 
        /// The flickr.places.findByLatLon method is not meant to be a (reverse) geocoder in the traditional sense. It
        /// is designed to allow users to find photos for "places" and will round up to the nearest place type to which
        /// corresponding place IDs apply.
        /// 
        /// For example, if you pass it a street level coordinate it will return the city that contains the point
        /// rather than the street, or building, itself.
        /// 
        /// It will also truncate latitudes and longitudes to three decimal points.
        /// </summary>
        /// <param name="latitude">The latitude whose valid range is -90 to 90. Anything more than 4 decimal places
        /// will be truncated.</param>
        /// <param name="longitude">The longitude whose valid range is -180 to 180. Anything more than 4 decimal places
        /// will be truncated.</param>
        /// <param name="accurary">Recorded accuracy level of the location information. <strong>World</strong> level is
        /// <code>1</code>, Country is <code>~3</code>, <strong>Region</strong> <code>~6</code>, <strong>City</strong>
        /// <code>~11</code>, <strong>Street</strong> <code>~16</code>. Current range is <code>1</code>-<code>16</code>.
        /// The default is <code>16</code>.</param>
        /// <returns>Returns an instance of <see cref="FlickrPlacesFindByLatLonResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.places.findByLatLon.htm</cref>
        /// </see>
        public FlickrPlacesFindByLatLonResponse FindByLatLon(double latitude, double longitude, int accurary) {
            return FlickrPlacesFindByLatLonResponse.ParseResponse(Raw.FindByLatLon(latitude, longitude, accurary));
        }

        #endregion

    }

}