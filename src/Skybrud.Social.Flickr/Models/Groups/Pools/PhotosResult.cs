using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Models.Groups.Pools {

    public class PhotosResult : FlickrObject {

        #region Properties
        
        public PhotosResultList Photos { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected PhotosResult(XElement xml) : base(xml) {
            Photos = xml.GetElement("photos", PhotosResultList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="PhotosResult"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="PhotosResult"/>.</returns>
        public static PhotosResult Parse(XElement xml) {
            return xml == null ? null : new PhotosResult(xml);
        }

        #endregion

    }

}