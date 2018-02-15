using System;
using System.Xml.Linq;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Photosets {
    
    /// <summary>
    /// Class representing a photoset.
    /// </summary>
    public class FlickrPhotoset : FlickrObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the photo.
        /// </summary>
        public string Id { get; }

        public string Owner { get; }

        public string Username { get; }

        public string Primary { get; }

        public string Secret { get; }

        public string Server { get; }

        public string Farm { get; }

        public int Photos { get; }

        public int Views { get; }

        public int Comments { get; }

        public int Videos { get; }

        public bool CanComment { get; }

        public EssentialsDateTime Created { get; }

        public EssentialsDateTime Updated { get; }

        public string CoverPhotoServer { get; }

        public string CoverPhotoFarm { get; }

        /// <summary>
        /// Gets the title of the photoset.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets whether the photoset has a title.
        /// </summary>
        public bool HasTitle => !String.IsNullOrWhiteSpace(Title);

        /// <summary>
        /// Gets the description of the photoset.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets whether the photoset has a description.
        /// </summary>
        public bool HasDescription => !String.IsNullOrWhiteSpace(Description);

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPhotoset(XElement xml) : base(xml) {

            // Parse attributes
            Id = xml.GetAttributeValue("id");
            Owner = xml.GetAttributeValue("owner");
            Username = xml.GetAttributeValue("username");
            Primary = xml.GetAttributeValue("primary");
            Secret = xml.GetAttributeValue("secret");
            Server = xml.GetAttributeValue("server");
            Farm = xml.GetAttributeValue("farm");
            Photos = xml.GetAttributeValueAsInt32("photos");
            Views = xml.GetAttributeValueAsInt32("count_views");
            Comments = xml.GetAttributeValueAsInt32("count_comments");
            Videos = xml.GetAttributeValueAsInt32("count_videos");
            CanComment = xml.GetAttributeValue("can_comment") == "1";
            Created = xml.GetAttributeValueAsInt64("date_create", EssentialsDateTime.FromUnixTimestamp);
            Updated = xml.GetAttributeValueAsInt64("date_update", EssentialsDateTime.FromUnixTimestamp);
            CoverPhotoServer = xml.GetAttributeValue("coverphoto_server");
            CoverPhotoFarm = xml.GetAttributeValue("coverphoto_farm");

            // Parse elements
            Title = xml.GetElementValue("title");
            Description = xml.GetElementValue("description");

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPhotoset"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrPhotoset"/>.</returns>
        public static FlickrPhotoset Parse(XElement xml) {
            return xml == null ? null : new FlickrPhotoset(xml);
        }

        #endregion

    }

}