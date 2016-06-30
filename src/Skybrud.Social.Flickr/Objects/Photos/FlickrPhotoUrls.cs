using System.Xml.Linq;
using Skybrud.Social.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects.Photos {
    
    public class FlickrPhotoUrls : FlickrObject {

        #region Properties

        /// <summary>
        /// Gets URL to the page on <strong>Flickr.com</strong> for the photo.
        /// </summary>
        public string PhotoPage { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPhotoUrls(XElement xml) : base(xml) {
            PhotoPage = xml.GetElementValue("url[@type='photopage']");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPhotoUrls"/> from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        public static FlickrPhotoUrls Parse(XElement xml) {
            return xml == null ? null : new FlickrPhotoUrls(xml);
        }

        #endregion

    }

}