using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Flickr.Options.Groups {

    /// <summary>
    /// Class representing the options for a call to the <c>flickr.groups.getInfo</c> Flickr API method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.groups.getInfo.html</cref>
    /// </see>
    public class FlickrGetGroupInfoOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the group to be retrieved. Either <see cref="GroupId"/> or
        /// <see cref="GroupPathAlias"/> must be specified.
        /// </summary>
        public string GroupId { get; set; }

        /// Gets or sets the path alias of the group to be retrieved. Either <see cref="GroupId"/> or
        /// <see cref="GroupPathAlias"/> must be specified.
        public string GroupPathAlias { get; set; }

        /// <summary>
        /// Gets or sets the language of the group name and description to fetch. If the language is not found, the
        /// primary language of the group will be returned. 
        /// </summary>
        public string Language { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public FlickrGetGroupInfoOptions() { }

        /// <summary>
        /// Initializes the options with the specified <paramref name="groupId"/>.
        /// </summary>
        /// <param name="groupId">The ID (NSID) of the group to fetch information for.</param>
        public FlickrGetGroupInfoOptions(string groupId) {
            GroupId = groupId;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {

            // Either "GroupId" or "GroupPathAlias" should be specified
            if (String.IsNullOrWhiteSpace(GroupId + GroupPathAlias)) throw new PropertyNotSetException("GroupId");

            // Append the options to the query string (if specified)
            SocialHttpQueryString query = new SocialHttpQueryString();
            query.Add("method", "flickr.groups.getInfo");
            if (!String.IsNullOrWhiteSpace(GroupId)) query.Add("group_id", GroupId);
            if (!String.IsNullOrWhiteSpace(GroupPathAlias)) query.Add("group_path_alias", GroupPathAlias);
            if (!String.IsNullOrWhiteSpace(Language)) query.Add("lang", Language);

            return query;

        }

        #endregion

    }

}