using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Flickr.Options.Galleries {

    /// <summary>
    /// Class representing the options for a call to the <c>flickr.galleries.getList</c> Flickr API method.
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
        /// <c>100</c>. The maximum allowed value is <c>500</c>.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets the page of results to return. If this argument is omitted, it defaults to <c>1</c>.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets list of extra information to fetch for the primary photo. Currently supported fields are:
        /// <c>license</c>, <c>date_upload</c>, <c>date_taken</c>, <c>owner_name</c>, <c>icon_server</c>,
        /// <c>original_format</c>, <c>last_update</c>, <c>geo</c>, <c>tags</c>, <c>machine_tags</c>, <c>o_dims</c>,
        /// <c>views</c>, <c>media</c>, <c>path_alias</c>, <c>url_sq</c>, <c>url_t</c>, <c>url_s</c>, <c>url_m</c>,
        /// <c>url_o</c>.
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
        /// to <c>100</c>. The maximum allowed value is <c>500</c>.</param>
        /// <param name="page">The page of results to return. If this argument is omitted, it defaults to
        /// <c>1</c>.</param>
        public FlickrGetGalleryListOptions(string userId, int perPage, int page) {
            UserId = userId;
            PerPage = perPage;
            Page = page;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
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