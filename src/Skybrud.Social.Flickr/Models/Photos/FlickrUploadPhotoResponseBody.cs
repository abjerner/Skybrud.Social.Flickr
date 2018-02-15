using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Models.Photos {

    /// <summary>
    /// Class representing the response body of a request to the Flickr API for uploading a photo.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/upload.api.html</cref>
    /// </see>
    public class FlickrUploadPhotoResponseBody : FlickrResponseBody {

        #region Properties

        /// <summary>
        /// Gets the ID of the uploaded photo.
        /// </summary>
        public string PhotoId { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrUploadPhotoResponseBody(XElement xml) : base(xml) {
            PhotoId = xml.GetElementValue("photoid");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrUploadPhotoResponseBody"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrUploadPhotoResponseBody"/>.</returns>
        public static FlickrUploadPhotoResponseBody Parse(XElement xml) {
            return xml == null ? null : new FlickrUploadPhotoResponseBody(xml);
        }

        #endregion

    }

}