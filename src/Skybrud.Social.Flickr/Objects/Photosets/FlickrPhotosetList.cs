using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Photosets {
    
    public class FlickrPhotosetList : FlickrObject, IEnumerable<FlickrPhotoset> {

        #region Properties

        public int Page { get; private set; }

        public int Pages { get; private set; }

        public int PerPage { get; private set; }

        public int Total { get; private set; }

        public bool CanCreate { get; private set; }

        protected FlickrPhotoset[] Items { get; private set; }

        public int Length {
            get { return Items.Length; }
        }

        public FlickrPhotoset this[int index] {
            get { return Items[index]; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPhotosetList(XElement xml) : base(xml) {

            // Parse attributes
            Page = xml.GetAttributeValueAsInt32("page");
            Pages = xml.GetAttributeValueAsInt32("pages");
            PerPage = xml.GetAttributeValueAsInt32("perpage");
            Total = xml.GetAttributeValueAsInt32("total");
            CanCreate = xml.GetAttributeAsBoolean("cancreate");

            // Parse elements
            Items = xml.GetElements("photoset", FlickrPhotoset.Parse);

        }

        #endregion

        #region Member methods

        public IEnumerator<FlickrPhotoset> GetEnumerator() {
            return ((IEnumerable<FlickrPhotoset>) Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPhotosetList"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPhotosetList Parse(XElement xml) {
            return xml == null ? null : new FlickrPhotosetList(xml);
        }

        #endregion

    }

}