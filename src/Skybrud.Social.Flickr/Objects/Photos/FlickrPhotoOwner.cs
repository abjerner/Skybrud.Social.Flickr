using System.Xml.Linq;
using Skybrud.Social.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Photos {
    
    public class FlickrPhotoOwner : FlickrObject {

        #region Properties

        /// <summary>
        /// Gets the ID (NSID) of the user.
        /// </summary>
        public string Id { get; private set; }

        public string Username { get; private set; }

        public string RealName { get; private set; }

        public string Location { get; private set; }

        public string IconServer { get; private set; }

        public string IconFarm { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPhotoOwner(XElement xml) : base(xml) {
            Id = xml.GetAttributeValue("nsid");
            Username = xml.GetAttributeValue("username");
            RealName = xml.GetAttributeValue("realname");
            Location = xml.GetAttributeValue("location");
            IconServer = xml.GetAttributeValue("iconserver");
            IconFarm = xml.GetAttributeValue("iconfarm");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPhotoOwner"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPhotoOwner Parse(XElement xml) {
            return xml == null ? null : new FlickrPhotoOwner(xml);
        }

        #endregion

    }

}