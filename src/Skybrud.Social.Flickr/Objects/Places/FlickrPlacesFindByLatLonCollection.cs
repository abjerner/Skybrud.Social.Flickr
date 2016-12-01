using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Places {
    
    public class FlickrPlacesFindByLatLonCollection : FlickrObject, IEnumerable<FlickrPlaceItem> {

        #region Properties

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public int Accuracy { get; private set; }

        public int Total { get; private set; }

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
        protected FlickrPlacesFindByLatLonCollection(XElement xml) : base(xml) {
            Latitude = xml.GetAttributeValueAsDouble("latitude");
            Longitude = xml.GetAttributeValueAsDouble("longitude");
            Accuracy = xml.GetAttributeValueAsInt32("accuracy");
            Total = xml.GetAttributeValueAsInt32("total");
            Items = xml.GetElements("place", FlickrPlaceItem.Parse);
        }

        #endregion

        #region Member methods

        public IEnumerator<FlickrPlaceItem> GetEnumerator() {
            return ((IEnumerable<FlickrPlaceItem>) Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPlacesFindByLatLonCollection"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPlacesFindByLatLonCollection Parse(XElement xml) {
            return xml == null ? null : new FlickrPlacesFindByLatLonCollection(xml);
        }

        #endregion

    }

}