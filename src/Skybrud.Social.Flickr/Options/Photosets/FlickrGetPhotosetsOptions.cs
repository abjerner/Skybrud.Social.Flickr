using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Flickr.Options.Photosets {
    
    /// <summary>
    /// Class representing the options for a request to get the photosets of a user.
    /// </summary>
    public class FlickrGetPhotosetsOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the page to be returned.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of photosets to be returned per page.
        /// </summary>
        public int PerPage { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public FlickrGetPhotosetsOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public FlickrGetPhotosetsOptions(string userId) {
            UserId = userId;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of photosets to be returned per page.</param>
        public FlickrGetPhotosetsOptions(string userId, int page, int perPage) {
            UserId = userId;
            Page = page;
            PerPage = perPage;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {
            if (string.IsNullOrWhiteSpace(UserId)) throw new PropertyNotSetException("UserId");
            HttpQueryString query = new HttpQueryString();
            query.Add("method", "flickr.photosets.getList");
            query.Add("user_id", UserId);
            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);
            return query;
        }

        #endregion

    }

}