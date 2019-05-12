using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Flickr.Options.Galleries {

    /// <summary>
    /// Class representing the options for a call to the <c>flickr.galleries.getInfo</c> Flickr API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.galleries.getInfo.html</cref>
    /// </see>
    public class FlickrGetGalleryInfoOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the gallery to be retrieved.
        /// </summary>
        public string GalleryId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public FlickrGetGalleryInfoOptions() { }

        /// <summary>
        /// Initializes the options with the specified <paramref name="galleryId"/>.
        /// </summary>
        /// <param name="galleryId">The ID (NSID) of the gallery to fetch information for.</param>
        public FlickrGetGalleryInfoOptions(string galleryId) {
            GalleryId = galleryId;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {

            // "GalleryId" must be specified
            if (string.IsNullOrWhiteSpace(GalleryId)) throw new PropertyNotSetException("GroupId");

            // Append the options to the query string (if specified)
            HttpQueryString query = new HttpQueryString();
            query.Add("method", "flickr.galleries.getInfo");
            query.Add("gallery_id", GalleryId);

            return query;

        }

        #endregion

    }

}