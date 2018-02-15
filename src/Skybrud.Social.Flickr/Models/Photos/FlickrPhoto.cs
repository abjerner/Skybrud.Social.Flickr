using System;
using System.Xml.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Xml.Extensions;
using Skybrud.Social.Flickr.Models.Places;

namespace Skybrud.Social.Flickr.Models.Photos {
    
    /// <summary>
    /// Class representing a Flickr photo.
    /// </summary>
    public class FlickrPhoto : FlickrObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the photo.
        /// </summary>
        public string Id { get; }

        public string Secret { get; }

        public string Server { get; }

        public string Farm { get; }

        /// <summary>
        /// Gets the timestamp for when the photo was uploaded.
        /// </summary>
        public EssentialsDateTime Uploaded { get; }

        /// <summary>
        /// Gets whether the authenticated user has favorited the photo.
        /// </summary>
        public bool IsFavorite { get; }

        /// <summary>
        /// Gets the ID of the license of the photo.
        /// </summary>
        public int LicenseId { get; }

        /// <summary>
        /// Gets the safety level of the photo.
        /// </summary>
        public FlickrPhotoSafetyLevel SafetyLevel { get; }

        // TODO: Implement property for attribute "rotation"

        public string OriginalSecret { get; }

        public string OriginalFormat { get; }

        /// <summary>
        /// Gets the amount of views the photo has received.
        /// </summary>
        public int Views { get; }

        // TODO: Implement property for attribute "media"

        /// <summary>
        /// Gets a reference to the owner of the photo.
        /// </summary>
        public FlickrPhotoOwner Owner { get; }

        /// <summary>
        /// Gets the title of the photo.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets whether the photo has a title.
        /// </summary>
        public bool HasTitle => !String.IsNullOrWhiteSpace(Title);

        /// <summary>
        /// Gets the description of the photo.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets whether the photo has a description.
        /// </summary>
        public bool HasDescription => !String.IsNullOrWhiteSpace(Description);

        public FlickrPhotoSafetyVisibility Visibility { get; }
        
        /// <summary>
        /// Gets a reference to the <see cref="FlickrPlace"/> representing the location of the photo. Use
        /// <see cref="HasLocation"/> to check whether a location has been specified for the photo.
        /// </summary>
        public FlickrPlace Location { get; }

        /// <summary>
        /// Gets whether a location has been specified for the photo.
        /// </summary>
        public bool HasLocation => Location != null;

        /// <summary>
        /// Gets a reference to the <see cref="FlickrPhotoUrls"/> with URLs of the photo.
        /// </summary>
        public FlickrPhotoUrls Urls { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPhoto(XElement xml) : base(xml) {

            // Parse attributes
            Id = xml.GetAttributeValue("id");
            Secret = xml.GetAttributeValue("secret");
            Server = xml.GetAttributeValue("server");
            Farm = xml.GetAttributeValue("farm");
            Uploaded = xml.GetAttributeValueAsInt64("dateuploaded", EssentialsDateTime.FromUnixTimestamp);
            IsFavorite = xml.GetAttributeValueAsBoolean("isfavorite");
            LicenseId = xml.GetAttributeValueAsInt32("license");
            SafetyLevel = xml.GetAttributeValueAsInt32("safety_level", ParseSafetyLevel);
            OriginalSecret = xml.GetAttributeValue("originalsecret");
            OriginalFormat = xml.GetAttributeValue("originalformat");
            Views = xml.GetAttributeValue<int>("views");

            // Parse child elements
            Owner = xml.GetElement("owner", FlickrPhotoOwner.Parse);
            Title = xml.GetElementValue("title");
            Description = xml.GetElementValue("description");
            Visibility = xml.GetElement("visibility", ParseVisibility);
            Location = xml.GetElement("location", FlickrPlace.Parse);
            Urls = xml.GetElement("urls", FlickrPhotoUrls.Parse);

        }

        #endregion

        #region Member methods

        /// <summary>
        /// Parses an integer value into an instance of the enum class <see cref="FlickrPhotoSafetyLevel"/>. The Flickr
        /// API doesn't use consitent integer values for the safety level across the API, hence the need for this
        /// method.
        /// 
        /// When receiving information about a photo, <c>0</c> equals <see cref="FlickrPhotoSafetyLevel.Safe"/>,
        /// <code>1</code> equals <see cref="FlickrPhotoSafetyLevel.Moderate"/> and <c>2</c> equals
        /// <see cref="FlickrPhotoSafetyLevel.Restricted"/>.
        /// 
        /// On the other hand, when uploading a photo, <c>1</c> equals <see cref="FlickrPhotoSafetyLevel.Safe"/>,
        /// <c>2</c> equals <see cref="FlickrPhotoSafetyLevel.Moderate"/> and <code>3</code> equals
        /// <see cref="FlickrPhotoSafetyLevel.Restricted"/>.
        /// </summary>
        /// <param name="value">The integer value to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrPhotoSafetyLevel"/>.</returns>
        private FlickrPhotoSafetyLevel ParseSafetyLevel(int value) {
            switch (value) {
                case 0: return FlickrPhotoSafetyLevel.Safe;
                case 1: return FlickrPhotoSafetyLevel.Moderate;
                case 2: return FlickrPhotoSafetyLevel.Restricted;
                default: throw new EnumParseException(typeof(FlickrPhotoSafetyLevel), value + "");
            }
        }

        private FlickrPhotoSafetyVisibility ParseVisibility(XElement xml) {

            if (xml.GetAttributeValue("ispublic") == "1") return FlickrPhotoSafetyVisibility.Public;

            string value = (xml.GetAttributeValue("isfriend") ?? "0") + "" + (xml.GetAttributeValue("isfamily") ?? "0");

            switch (value) {
                case "11": return FlickrPhotoSafetyVisibility.FriendsAndFamily;
                case "10": return FlickrPhotoSafetyVisibility.Friends;
                case "01": return FlickrPhotoSafetyVisibility.Family;
                default: return FlickrPhotoSafetyVisibility.Private; 
            }

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPhoto"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrPhoto"/>.</returns>
        public static FlickrPhoto Parse(XElement xml) {
            return xml == null ? null : new FlickrPhoto(xml);
        }

        #endregion

    }

}