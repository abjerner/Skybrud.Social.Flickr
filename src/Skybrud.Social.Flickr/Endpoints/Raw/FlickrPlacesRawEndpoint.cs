using System;
using System.Collections.Specialized;
using System.Globalization;
using Skybrud.Social.Flickr.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the places Flickr endpoint.
    /// </summary>
    public class FlickrPlacesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr OAuth client.
        /// </summary>
        public FlickrOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instanced based on the <paramref name="client"/>.
        /// </summary>
        /// <param name="client">An instance of <see cref="FlickrOAuthClient"/> representing the parent OAuth client.</param>
        internal FlickrPlacesRawEndpoint(FlickrOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Return a list of places matching the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The query string to use for place ID lookups.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.places.find.htm</cref>
        /// </see>
        public SocialHttpResponse Find(string query) {
            if (String.IsNullOrWhiteSpace(query)) throw new ArgumentNullException("query");
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new NameValueCollection {
                {"method", "flickr.places.find"},
                {"query", query}
            });
        }

        /// <summary>
        /// Returns a place for the specified <paramref name="latitude"/> and <see cref="longitude"/>.
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
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.places.findByLatLon.htm</cref>
        /// </see>
        public SocialHttpResponse FindByLatLon(double latitude, double longitude) {
            return FindByLatLon(latitude, longitude, 16);
        }

        /// <summary>
        /// Returns a place for the specified <paramref name="latitude"/> and <see cref="longitude"/>.
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
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.places.findByLatLon.htm</cref>
        /// </see>
        public SocialHttpResponse FindByLatLon(double latitude, double longitude, int accurary) {
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new NameValueCollection {
                {"method", "flickr.places.findByLatLon"},
                {"lat", latitude.ToString(CultureInfo.InvariantCulture)},
                {"lon", longitude.ToString(CultureInfo.InvariantCulture)}
            });
        }

        /// <summary>
        /// Gets information about the place with the specified <paramref name="placeId"/>.
        /// </summary>
        /// <param name="placeId">The ID of the place to fetch information about.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.places.getInfo.html</cref>
        /// </see>
        public SocialHttpResponse GetInfo(string placeId) {
            if (String.IsNullOrWhiteSpace(placeId)) throw new ArgumentNullException("placeId");
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new NameValueCollection {
                {"method", "flickr.places.getInfo"},
                {"place_id", placeId}
            });
        }

        #endregion

    }

}