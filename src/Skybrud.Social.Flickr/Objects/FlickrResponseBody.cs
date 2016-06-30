using System.Xml.Linq;
using Skybrud.Social.Xml.Extensions;

namespace Skybrud.Social.Flickr.Objects {
    
    /// <summary>
    /// Class representing a generic response body from the Flickr API derived from an instance of <see cref="XElement"/>.
    /// </summary>
    public class FlickrResponseBody : FlickrObject {

        #region Properties

        public string Status { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrResponseBody(XElement xml) : base(xml) {
            Status = xml.GetAttributeValue("stat");
        }

        #endregion

    }

}