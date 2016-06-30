using System.Xml.Linq;
using Newtonsoft.Json;

namespace Skybrud.Social.Flickr.Objects {
    
    /// <summary>
    /// Class representing a basic object from the Flickr API derived from an instance of <see cref="XElement"/>.
    /// </summary>
    public class FlickrObject {

        #region Properties

        [JsonIgnore]
        public XElement XElement { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>xml</code>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrObject(XElement xml) {
            XElement = xml;
        }

        #endregion

    }

}