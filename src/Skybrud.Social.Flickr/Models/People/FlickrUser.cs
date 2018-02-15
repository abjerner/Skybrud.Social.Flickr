using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Models.People {
    
    public class FlickrUser : FlickrObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the person.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the username of the person.
        /// </summary>
        public string Username { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrUser(XElement xml) : base(xml) {
            Id = xml.GetAttributeValue("id");
            Username = xml.GetElementValue("username");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrUser"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrGetPhotosetInfoResponseBody"/>.</returns>
        public static FlickrUser Parse(XElement xml) {
            return xml == null ? null : new FlickrUser(xml);
        }

        #endregion

    }

}