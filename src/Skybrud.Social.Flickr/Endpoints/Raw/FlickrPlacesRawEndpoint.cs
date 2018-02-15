using System;
using System.Globalization;
using Skybrud.Social.Flickr.Models.Places;
using Skybrud.Social.Flickr.OAuth;
using Skybrud.Social.Flickr.Options.Places;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Places</strong> Flickr endpoint.
    /// </summary>
    public class FlickrPlacesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Flickr OAuth client.
        /// </summary>
        public FlickrOAuthClient Client { get; }

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
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.places.find.htm</cref>
        /// </see>
        public SocialHttpResponse Find(string query) {
            if (String.IsNullOrWhiteSpace(query)) throw new ArgumentNullException("query");
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new SocialHttpQueryString {
                {"method", "flickr.places.find"},
                {"query", query}
            });
        }

        /// <summary>
        /// Returns a place for the specified <paramref name="latitude"/> and <paramref name="longitude"/>.
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
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.places.findByLatLon.htm</cref>
        /// </see>
        public SocialHttpResponse FindByLatLon(double latitude, double longitude) {
            return FindByLatLon(latitude, longitude, 16);
        }

        /// <summary>
        /// Returns a place for the specified <paramref name="latitude"/> and <paramref name="longitude"/>.
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
        /// <c>1</c>, Country is <c>~3</c>, <strong>Region</strong> <c>~6</c>, <strong>City</strong>
        /// <c>~11</c>, <strong>Street</strong> <c>~16</c>. Current range is <c>1</c>-<c>16</c>.
        /// The default is <c>16</c>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.places.findByLatLon.htm</cref>
        /// </see>
        public SocialHttpResponse FindByLatLon(double latitude, double longitude, int accurary) {
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new SocialHttpQueryString {
                {"method", "flickr.places.findByLatLon"},
                {"lat", latitude.ToString(CultureInfo.InvariantCulture)},
                {"lon", longitude.ToString(CultureInfo.InvariantCulture)}
            });
        }

        // TODO: https://www.flickr.com/services/api/flickr.places.getChildrenWithPhotosPublic.html

        /// <summary>
        /// Gets information about the place with the specified <paramref name="placeId"/>.
        /// </summary>
        /// <param name="placeId">The ID of the place to fetch information about.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.flickr.com/services/api/flickr.places.getInfo.html</cref>
        /// </see>
        public SocialHttpResponse GetInfo(string placeId) {
            if (String.IsNullOrWhiteSpace(placeId)) throw new ArgumentNullException(nameof(placeId));
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", new SocialHttpQueryString {
                {"method", "flickr.places.getInfo"},
                {"place_id", placeId}
            });
        }

        // TODO: https://www.flickr.com/services/api/flickr.places.getInfoByUrl.html

        // TODO: https://www.flickr.com/services/api/flickr.places.getPlaceTypes.html

        // TODO: https://www.flickr.com/services/api/flickr.places.getShapeHistory.html

        // TODO: https://www.flickr.com/services/api/flickr.places.getTopPlacesList.html

        // TODO: https://www.flickr.com/services/api/flickr.places.placesForBoundingBox.html

        // TODO: https://www.flickr.com/services/api/flickr.places.placesForContacts.html

        /// <summary>
        /// Gets a list of the top 100 unique places clustered by a given placetype for a user's contacts.
        /// </summary>
        /// <param name="placeType">A place type to cluster photos by. </param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse PlacesForContacts(FlickrPlaceType placeType) {
            return PlacesForContacts(new FlickrGetPlacesForContactsOptions {
                PlaceType = placeType
            });
        }

        /// <summary>
        /// Gets a list of the top 100 unique places clustered by a given placetype for a user's contacts.
        /// </summary>
        /// <param name="placeType">A place type to cluster photos by. </param>
        /// <param name="placeId">A Flickr Places identifier to use to filter photo clusters.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse PlacesForContacts(FlickrPlaceType placeType, string placeId) {
            return PlacesForContacts(new FlickrGetPlacesForContactsOptions {
                PlaceType = placeType,
                PlaceId = placeId
            });
        }

        /// <summary>
        /// Gets a list of the top 100 unique places clustered by a given placetype for a user's contacts.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse PlacesForContacts(FlickrGetPlacesForContactsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", options);
        }
        
        public SocialHttpResponse GetPlacesForTags(FlickrPlaceType placeType, string[] tags) {
            return GetPlacesForTags(new FlickrGetPlacesForTagsOptions {
                PlaceType = placeType,
                Tags = tags
            });
        }

        public SocialHttpResponse GetPlacesForTags(FlickrGetPlacesForTagsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("https://api.flickr.com/services/rest", options);
        }
        
        // TODO: https://www.flickr.com/services/api/flickr.places.placesForUser.html

        // TODO: https://www.flickr.com/services/api/flickr.places.tagsForPlace.html

        #endregion

    }

}