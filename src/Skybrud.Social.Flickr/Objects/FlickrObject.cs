using System.Xml.Linq;
using Skybrud.Essentials.Xml;

namespace Skybrud.Social.Flickr.Objects {
    
    /// <summary>
    /// Class representing a basic object from the Flickr API derived from an instance of <see cref="XElement"/>.
    /// </summary>
    public class FlickrObject : XmlObjectBase {

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected FlickrObject(XElement xml) : base(xml) { }

        #endregion

    }

}