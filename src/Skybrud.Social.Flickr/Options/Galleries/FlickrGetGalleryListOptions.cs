using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Flickr.Options.Galleries {

    /// <summary>
    /// Class representing the options for a call to the <code>flickr.galleries.getList</code> Flickr API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.galleries.getList.html</cref>
    /// </see>
    public class FlickrGetGalleryListOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID (NSID) of the user to get a galleries list for. If none is specified, the calling user
        /// is assumed.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the number of galleries to return per page. If this argument is omitted, it defaults to
        /// <code>100</code>. The maximum allowed value is <code>500</code>.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets the page of results to return. If this argument is omitted, it defaults to <code>1</code>.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets list of extra information to fetch for the primary photo. Currently supported fields are:
        /// <code>license</code>, <code>date_upload</code>, <code>date_taken</code>, <code>owner_name</code>,
        /// <code>icon_server</code>, <code>original_format</code>, <code>last_update</code>, <code>geo</code>,
        /// <code>tags</code>, <code>machine_tags</code>, <code>o_dims</code>, <code>views</code>, <code>media</code>,
        /// <code>path_alias</code>, <code>url_sq</code>, <code>url_t</code>, <code>url_s</code>, <code>url_m</code>,
        /// <code>url_o</code>.
        /// </summary>
        public string[] PrimaryPhotoExtras { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public FlickrGetGalleryListOptions() { }

        /// <summary>
        /// Initializes the options with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID (NSID) of the user to get a galleries list for. If none is specified, the
        /// calling user is assumed.</param>
        public FlickrGetGalleryListOptions(string userId) {
            UserId = userId;
        }

        /// <summary>
        /// Initializes the options with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID (NSID) of the user to get a galleries list for. If none is specified, the
        /// calling user is assumed.</param>
        /// <param name="perPage">The number of galleries to return per page. If this argument is omitted, it defaults
        /// to <code>100</code>. The maximum allowed value is <code>500</code>.</param>
        /// <param name="page">The page of results to return. If this argument is omitted, it defaults to
        /// <code>1</code>.</param>
        public FlickrGetGalleryListOptions(string userId, int perPage, int page) {
            UserId = userId;
            PerPage = perPage;
            Page = page;
        }

        #endregion

        #region Member methods

        public IHttpQueryString GetQueryString() {
            SocialHttpQueryString query = new SocialHttpQueryString();
            query.Add("method", "flickr.galleries.getList");
            if (!String.IsNullOrWhiteSpace(UserId)) query.Add("user_id ", UserId);
            if (PerPage > 0) query.Add("per_page ", PerPage);
            if (Page > 0) query.Add("page ", Page);
            return query;
        }

        #endregion

    }

}