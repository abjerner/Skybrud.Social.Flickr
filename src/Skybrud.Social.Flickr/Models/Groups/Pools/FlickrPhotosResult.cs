using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Models.Groups.Pools {

    public class FlickrPhotosResult : FlickrObject {

        #region Properties
        
        public FlickrPhotosResultList Photos { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrPhotosResult(XElement xml) : base(xml) {
            Photos = xml.GetElement("photos", FlickrPhotosResultList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="FlickrPhotosResult"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="FlickrPhotosResult"/>.</returns>
        public static FlickrPhotosResult Parse(XElement xml) {
            return xml == null ? null : new FlickrPhotosResult(xml);
        }

        #endregion

    }

}