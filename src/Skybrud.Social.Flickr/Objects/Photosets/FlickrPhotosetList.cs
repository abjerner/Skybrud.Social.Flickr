using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Photosets {

    /// <summary>
    /// Class representing a list of <see cref="FlickrPhotoset"/>.
    /// </summary>
    public class FlickrPhotosetList : FlickrObject, IEnumerable<FlickrPhotoset> {

        #region Properties

        /// <summary>
        /// Gets the current page.
        /// </summary>
        public int Page { get; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        public int Pages { get; }

        /// <summary>
        /// Gets the amount of items returned page page.
        /// </summary>
        public int PerPage { get; }

        /// <summary>
        /// Gets the total amount of photosets.
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Gets whether the authenticated user can create a new photoset.
        /// </summary>
        public bool CanCreate { get; }

        /// <summary>
        /// Gets an array with the items in the collection.
        /// </summary>
        protected FlickrPhotoset[] Items { get; }

        /// <summary>
        /// Gets the length of the collection.
        /// </summary>
        public int Length => Items.Length;

        /// <summary>
        /// Gets the photoset at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index of the photoset </param>
        /// <returns>An instance of <see cref="FlickrPhotoset"/>.</returns>
        public FlickrPhotoset this[int index] => Items[index];

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPhotosetList(XElement xml) : base(xml) {

            // Parse attributes
            Page = xml.GetAttributeValueAsInt32("page");
            Pages = xml.GetAttributeValueAsInt32("pages");
            PerPage = xml.GetAttributeValueAsInt32("perpage");
            Total = xml.GetAttributeValueAsInt32("total");
            CanCreate = xml.GetAttributeValueAsBoolean("cancreate");

            // Parse elements
            Items = xml.GetElements("photoset", FlickrPhotoset.Parse);

        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An instanceo of <see cref="IEnumerator{FlickrPhotoset}"/>.</returns>
        public IEnumerator<FlickrPhotoset> GetEnumerator() {
            return ((IEnumerable<FlickrPhotoset>) Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPhotosetList"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrPhotosetList"/>.</returns>
        public static FlickrPhotosetList Parse(XElement xml) {
            return xml == null ? null : new FlickrPhotosetList(xml);
        }

        #endregion

    }

}