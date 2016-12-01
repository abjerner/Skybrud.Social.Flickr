using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Photosets {

    /// <summary>
    /// Class representing the response body of a request to the Flickr API for getting a list of photosets.
    /// </summary>
    public class FlickrGetPhotosetListResponseBody : FlickrResponseBody {

        #region Properties

        public FlickrPhotosetList Photosets { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrGetPhotosetListResponseBody(XElement xml) : base(xml) {
            Photosets = xml.GetElement("photosets", FlickrPhotosetList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrGetPhotosetListResponseBody"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrGetPhotosetListResponseBody Parse(XElement xml) {
            return xml == null ? null : new FlickrGetPhotosetListResponseBody(xml);
        }

        #endregion

    }

}