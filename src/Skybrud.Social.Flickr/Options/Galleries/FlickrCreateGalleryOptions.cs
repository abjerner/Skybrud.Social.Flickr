using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Flickr.Options.Galleries {

    /// <summary>
    /// Class representing the options for a call to the <c>flickr.galleries.create</c> Flickr API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.galleries.create.html</cref>
    /// </see>
    public class FlickrCreateGalleryOptions : IHttpPostOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the title/name of the gallery.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the gallery.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ID of the first photo to add to your gallery.
        /// </summary>
        public string PrimaryPhotoId  { get; set; }

        //public bool full_result { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public FlickrCreateGalleryOptions() { }

        /// <summary>
        /// Initializes the options with the specified <paramref name="title"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="title">The title/name of the gallery.</param>
        /// <param name="description">The description of the gallery.</param>
        public FlickrCreateGalleryOptions(string title, string description) {
            Title = title;
            Description = description;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {
            HttpQueryString query = new HttpQueryString();
            query.Add("method", "flickr.galleries.create");
            return query;
        }

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpPostData GetPostData() {

            // Both "Title" or "Description" should be specified
            if (string.IsNullOrWhiteSpace(Title)) throw new PropertyNotSetException("Title");
            if (string.IsNullOrWhiteSpace(Description)) throw new PropertyNotSetException("Description");

            // Append the options to the POST data (if specified)
            HttpPostData data = new HttpPostData();
            data.Add("title", Title);
            data.Add("description", Description);
            if (!string.IsNullOrWhiteSpace(PrimaryPhotoId)) data.Add("primary_photo_id ", PrimaryPhotoId);

            // TODO: The "full_result" parameter should be supported as well, but the Flickr API documentation doesn't specify it's type

            return data;

        }

        #endregion

    }

}