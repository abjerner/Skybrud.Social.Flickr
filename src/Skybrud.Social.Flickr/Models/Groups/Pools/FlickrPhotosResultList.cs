﻿using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Models.Groups.Pools {

    public class FlickrPhotosResultList : FlickrObject {

        #region Properties
        
        public int Page { get; }

        public int Pages { get; }

        public int PerPage { get; }

        public int Total { get; }

        public FlickrPhotosResultItem[] Photos { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPhotosResultList(XElement xml) : base(xml) {
            Page = xml.GetAttributeValueAsInt32("page");
            Pages = xml.GetAttributeValueAsInt32("pages");
            PerPage = xml.GetAttributeValueAsInt32("perpage");
            Total = xml.GetAttributeValueAsInt32("total");
            Photos = xml.GetElements("photo", FlickrPhotosResultItem.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPhotosResultList"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrPhotosResultList"/>.</returns>
        public static FlickrPhotosResultList Parse(XElement xml) {
            return xml == null ? null : new FlickrPhotosResultList(xml);
        }

        #endregion

    }

}