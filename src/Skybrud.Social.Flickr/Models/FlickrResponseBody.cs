using System.Xml.Linq;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Models {
    
    /// <summary>
    /// Class representing a generic response body from the Flickr API derived from an instance of <see cref="XElement"/>.
    /// </summary>
    public class FlickrResponseBody : FlickrObject {

        #region Properties

        /// <summary>
        /// Gets the status of the response.
        /// </summary>
        public string Status { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrResponseBody(XElement xml) : base(xml) {
            Status = xml.GetAttributeValue("stat");
        }

        #endregion

    }

}