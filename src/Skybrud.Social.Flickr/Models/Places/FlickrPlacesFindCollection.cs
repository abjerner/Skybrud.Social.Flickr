using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Models.Places {

    /// <summary>
    /// Class representing a collection of <see cref="FlickrPlaceItem"/> as returned by <c>flickr.places.find</c> API
    /// method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.places.find.html</cref>
    /// </see>
    public class FlickrPlacesFindCollection : FlickrObject, IEnumerable<FlickrPlaceItem> {

        #region Properties

        /// <summary>
        /// The search query as specified in the request to the Flickr API. 
        /// </summary>
        public string Query { get; }

        /// <summary>
        /// Gets the total amount of places returned by the search.
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Gets an array of <see cref="FlickrPlaceItem"/> with the matched places.
        /// </summary>
        public FlickrPlaceItem[] Items { get; }

        /// <summary>
        /// Gets a reference to the <see cref="FlickrPlaceItem"/> at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index of the item to be returned.</param>
        /// <returns>Returns an instance of <see cref="FlickrPlaceItem"/>.</returns>
        public FlickrPlaceItem this[int index] => Items[index];

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPlacesFindCollection(XElement xml) : base(xml) {
            Query = xml.GetAttributeValue("query");
            Total = xml.GetAttributeValueAsInt32("total");
            Items = xml.GetElements("place", FlickrPlaceItem.Parse);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An instanceo of <see cref="IEnumerator{FlickrPlaceItem}"/>.</returns>
        public IEnumerator<FlickrPlaceItem> GetEnumerator() {
            return ((IEnumerable<FlickrPlaceItem>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPlacesFindCollection"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrPlacesFindCollection"/>.</returns>
        public static FlickrPlacesFindCollection Parse(XElement xml) {
            return xml == null ? null : new FlickrPlacesFindCollection(xml);
        }

        #endregion

    }

}