using System.Collections.Generic;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Flickr.Options.Groups.Pools {

    /// <summary>
    /// Class representing the options for a request to the <c>flickr.groups.pools.getPhotos</c> Flickr API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.groups.pools.getPhotos.html</cref>
    /// </see>
    public class FlickrGroupsPoolsGetPhotosOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the id of the group who's pool you which to get the photo list for.
        /// </summary>
        public string GroupId { get; set; }

        /// Gets or sets a list of extra information to fetch for each returned record. Currently supported fields are:
        /// <c>description</c>, <c>license</c>, <c>date_upload</c>, <c>date_taken</c>, <c>owner_name</c>,
        /// <c>icon_server</c>, <c>original_format</c>, <c>last_update</c>, <c>geo</c>, <c>tags</c>,
        /// <c>machine_tags</c>, <c>o_dims</c>, <c>views</c>, <c>media</c>, <c>path_alias</c>, <c>url_sq</c>,
        /// <c>url_t</c>, <c>url_s</c>, <c>url_q</c>, <c>url_m</c>, <c>url_n</c>, <c>url_z</c>, <c>url_c</c>,
        /// <c>url_l</c> and <c>url_o</c>
        public List<string> Extras { get; set; }

        /// <summary>
        /// Gets or sets the number of photos to return per page. If this argument is omitted, it defaults to <c>100</c>. The maximum allowed value is <c>500</c>.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets the page of results to return. If this argument is omitted, it defaults to <c>1</c>.
        /// </summary>
        public int Page { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public FlickrGroupsPoolsGetPhotosOptions() { }

        /// <summary>
        /// Initializes the options with the specified <paramref name="groupId"/>.
        /// </summary>
        /// <param name="groupId">The ID (NSID) of the group to fetch information for.</param>
        public FlickrGroupsPoolsGetPhotosOptions(string groupId) {
            GroupId = groupId;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {

            // Either "GroupId" or "GroupPathAlias" should be specified
            if (string.IsNullOrWhiteSpace(GroupId)) throw new PropertyNotSetException(nameof(GroupId));

            // Append the options to the query string (if specified)
            HttpQueryString query = new HttpQueryString {
                {"method", "flickr.groups.pools.getPhotos"},
                { "group_id", GroupId}
            };

			if (Extras != null && Extras.Count > 0) query.Add("extras", string.Join(",", Extras));

            if (PerPage > 0) query.Add("per_page", PerPage);
            if (Page > 0) query.Add("page", Page);

            return query;

        }

        #endregion

    }

}