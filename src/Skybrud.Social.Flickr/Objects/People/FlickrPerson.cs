using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.People {
    
    public class FlickrPerson : FlickrObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the person.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the path alias of the person.
        /// </summary>
        public string PathAlias { get; private set; }

        /// <summary>
        /// Gets the username of the person.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the real name of the person.
        /// </summary>
        public string RealName { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPerson(XElement xml) : base(xml) {
            Id = xml.GetAttributeValue("id");
            PathAlias = xml.GetAttributeValue("path_alias");
            Username = xml.GetElementValue("username");
            RealName = xml.GetElementValue("realname");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPerson"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPerson Parse(XElement xml) {
            return xml == null ? null : new FlickrPerson(xml);
        }

        #endregion

    }

}