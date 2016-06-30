using System;
using System.Xml.Linq;
using Skybrud.Social.Exceptions;
using Skybrud.Social.Flickr.Enums;
using Skybrud.Social.Flickr.Objects.Places;
using Skybrud.Social.Time;
using Skybrud.Social.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Photosets {
    
    public class FlickrPhotoset : FlickrObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the photo.
        /// </summary>
        public string Id { get; private set; }

        public string Owner { get; private set; }

        public string Username { get; private set; }

        public string Primary { get; private set; }

        public string Secret { get; private set; }

        public string Server { get; private set; }

        public string Farm { get; private set; }

        public int Photos { get; private set; }

        public int Views { get; private set; }

        public int Comments { get; private set; }

        public int Videos { get; private set; }

        public bool CanComment { get; private set; }

        public SocialDateTime Created { get; private set; }

        public SocialDateTime Updated { get; private set; }

        public string CoverPhotoServer { get; private set; }

        public string CoverPhotoFarm { get; private set; }

        /// <summary>
        /// Gets the title of the photoset.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets whether the photoset has a title.
        /// </summary>
        public bool HasTitle {
            get { return !String.IsNullOrWhiteSpace(Title); }
        }

        /// <summary>
        /// Gets the description of the photoset.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets whether the photoset has a description.
        /// </summary>
        public bool HasDescription {
            get { return !String.IsNullOrWhiteSpace(Description); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
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
            Photos = xml.GetAttributeAsInt32("photos");
            Views = xml.GetAttributeAsInt32("count_views");
            Comments = xml.GetAttributeAsInt32("count_comments");
            Videos = xml.GetAttributeAsInt32("count_videos");
            CanComment = xml.GetAttributeValue("can_comment") == "1";
            Created = xml.GetAttributeAsInt64("date_create", SocialDateTime.FromUnixTimestamp);
            Updated = xml.GetAttributeAsInt64("date_update", SocialDateTime.FromUnixTimestamp);
            CoverPhotoServer = xml.GetAttributeValue("coverphoto_server");
            CoverPhotoFarm = xml.GetAttributeValue("coverphoto_farm");

            // Parse elements
            Title = xml.GetElementValue("title");
            Description = xml.GetElementValue("description");

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPhotoset"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPhotoset Parse(XElement xml) {
            return xml == null ? null : new FlickrPhotoset(xml);
        }

        #endregion

    }

}