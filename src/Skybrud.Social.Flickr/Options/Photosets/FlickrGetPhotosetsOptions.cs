using System;
using Skybrud.Social.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Flickr.Options.Photosets {
    
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

        public FlickrGetPhotosetsOptions() { }

        public FlickrGetPhotosetsOptions(string userId) {
            UserId = userId;
        }

        public FlickrGetPhotosetsOptions(string userId, int page, int perPage) {
            UserId = userId;
            Page = page;
            PerPage = perPage;
        }

        #endregion

        #region Member methods

        public IHttpQueryString GetQueryString() {
            if (String.IsNullOrWhiteSpace(UserId)) throw new PropertyNotSetException("UserId");
            SocialHttpQueryString query = new SocialHttpQueryString();
            query.Add("method", "flickr.photosets.getList");
            query.Add("user_id", UserId);
            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);
            return query;
        }

        #endregion

    }

}