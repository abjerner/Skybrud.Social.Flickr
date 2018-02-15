using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Models.Photos {

    /// <summary>
    /// Class representing the response body of a request to the Flickr API for getting information about a photo.
    /// </summary>
    public class FlickrGetPhotoResponseBody : FlickrResponseBody {

        #region Properties

        /// <summary>
        /// Gets a reference to the photo.
        /// </summary>
        public FlickrPhoto Photo { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrGetPhotoResponseBody(XElement xml) : base(xml) {
            Photo = xml.GetElement("photo", FlickrPhoto.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrGetPhotoResponseBody"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrGetPhotoResponseBody"/>.</returns>
        public static FlickrGetPhotoResponseBody Parse(XElement xml) {
            return xml == null ? null : new FlickrGetPhotoResponseBody(xml);
        }

        #endregion

    }

}