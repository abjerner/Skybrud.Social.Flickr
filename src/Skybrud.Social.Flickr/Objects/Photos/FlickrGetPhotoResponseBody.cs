using System.Xml.Linq;
using Skybrud.Social.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Photos {

    /// <summary>
    /// Class representing the response body of a request to the Flickr API for getting information about a photo.
    /// </summary>
    public class FlickrGetPhotoResponseBody : FlickrResponseBody {

        #region Properties

        public FlickrPhoto Photo { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrGetPhotoResponseBody(XElement xml) : base(xml) {
            Photo = xml.GetElement("photo", FlickrPhoto.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrGetPhotoResponseBody"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrGetPhotoResponseBody Parse(XElement xml) {
            return xml == null ? null : new FlickrGetPhotoResponseBody(xml);
        }

        #endregion

    }

}