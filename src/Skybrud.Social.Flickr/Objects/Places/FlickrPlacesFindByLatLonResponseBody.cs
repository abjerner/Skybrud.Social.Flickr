﻿using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Places {
    
    /// <summary>
    /// Class representing the response body as returned by the <code>flickr.places.findByLatLon</code> API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.places.findByLatLon.html</cref>
    /// </see>
    public class FlickrPlacesFindByLatLonResponseBody : FlickrResponseBody {

        #region Properties

        /// <summary>
        /// Gets a reference to a collection of the places matching the latitude and longitude as specified in the
        /// request to the <code>flickr.places.findByLatLon</code> API method.
        /// </summary>
        public FlickrPlacesFindByLatLonCollection Places { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPlacesFindByLatLonResponseBody(XElement xml) : base(xml) {
            Places = xml.GetElement("places", FlickrPlacesFindByLatLonCollection.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPlacesFindByLatLonResponseBody"/> from the specified
        /// <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPlacesFindByLatLonResponseBody Parse(XElement xml) {
            return xml == null ? null : new FlickrPlacesFindByLatLonResponseBody(xml);
        }

        #endregion

    }

}