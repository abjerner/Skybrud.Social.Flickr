using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Places {

    public class FlickrPlacesFindCollection : FlickrObject, IEnumerable<FlickrPlaceItem> {

        #region Properties

        public string Query { get; private set; }

        public int Total { get; private set; }

        /// <summary>
        /// Gets a reference to an array of <see cref="FlickrPlaceItem"/> with brief information about each place.
        /// </summary>
        public FlickrPlaceItem[] Items { get; private set; }

        public FlickrPlaceItem this[int index] {
            get { return Items[index]; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPlacesFindCollection(XElement xml) : base(xml) {
            Query = xml.GetAttributeValue("query");
            Total = xml.GetAttributeValueAsInt32("total");
            Items = xml.GetElements("place", FlickrPlaceItem.Parse);
        }

        #endregion

        #region Member methods

        public IEnumerator<FlickrPlaceItem> GetEnumerator() {
            return ((IEnumerable<FlickrPlaceItem>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPlacesFindCollection"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPlacesFindCollection Parse(XElement xml) {
            return xml == null ? null : new FlickrPlacesFindCollection(xml);
        }

        #endregion

    }

}