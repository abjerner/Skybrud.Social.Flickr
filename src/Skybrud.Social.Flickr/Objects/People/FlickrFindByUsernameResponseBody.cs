using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.People {

    public class FlickrFindByUsernameResponseBody : FlickrResponseBody {

        #region Properties

        /// <summary>
        /// Gets a reference to an instance of <see cref="FlickrUser"/> with brief information about the person/user.
        /// </summary>
        public FlickrUser User { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrFindByUsernameResponseBody(XElement xml) : base(xml) {
            User = xml.GetElement("user", FlickrUser.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrFindByUsernameResponseBody"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrGetPhotosetInfoResponseBody"/>.</returns>
        public static FlickrFindByUsernameResponseBody Parse(XElement xml) {
            return xml == null ? null : new FlickrFindByUsernameResponseBody(xml);
        }

        #endregion

    }

}