using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Models.People {

    public class FlickrGetPersonResponseBody : FlickrResponseBody {

        #region Properties

        /// <summary>
        /// Gets a reference to an instance of <see cref="FlickrPerson"/> with information about the person/user.
        /// </summary>
        public FlickrPerson Person { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrGetPersonResponseBody(XElement xml) : base(xml) {
            Person = xml.GetElement("person", FlickrPerson.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrGetPersonResponseBody"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrGetPhotosetInfoResponseBody"/>.</returns>
        public static FlickrGetPersonResponseBody Parse(XElement xml) {
            return xml == null ? null : new FlickrGetPersonResponseBody(xml);
        }

        #endregion

    }

}