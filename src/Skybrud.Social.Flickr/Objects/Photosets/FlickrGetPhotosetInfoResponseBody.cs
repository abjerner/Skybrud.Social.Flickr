using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Photosets {

    /// <summary>
    /// Class representing the response body of a request to the Flickr API for getting information about a photoset.
    /// </summary>
    public class FlickrGetPhotosetInfoResponseBody : FlickrResponseBody {

        #region Properties

        public FlickrPhotoset Photoset { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrGetPhotosetInfoResponseBody(XElement xml) : base(xml) {
            Photoset = xml.GetElement("photoset", FlickrPhotoset.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrGetPhotosetInfoResponseBody"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrGetPhotosetInfoResponseBody Parse(XElement xml) {
            return xml == null ? null : new FlickrGetPhotosetInfoResponseBody(xml);
        }

        #endregion

    }

}