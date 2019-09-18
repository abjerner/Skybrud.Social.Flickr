using System.Xml.Linq;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Xml.Extensions;

namespace Skybrud.Social.Flickr.Models.Groups.Pools {

    public class PhotosResultItem : FlickrObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the photo.
        /// </summary>
        public string Id { get; }

        public string Owner { get; }

        public string Server { get; }

        public string Farm { get; }

        public string Title { get; }

        public bool IsPublic { get; }

        public string OwnerName { get; }

        public EssentialsTime DateAdded { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public int Accuracy { get; }

        public string PlaceId { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> representing the object.</param>
        protected PhotosResultItem(XElement xml) : base(xml) {
            Id = xml.GetAttributeValue("id");
            Owner = xml.GetAttributeValue("owner");
            Server = xml.GetAttributeValue("server");
            Farm = xml.GetAttributeValue("farm");
            Title = xml.GetAttributeValue("title");
            IsPublic = xml.GetAttributeValueAsBoolean("is_public");
            OwnerName = xml.GetAttributeValue("ownername");
            DateAdded = xml.GetAttributeValueAsInt64("dateadded", EssentialsTime.FromUnixTimestamp);
            Latitude = xml.GetAttributeValue<double>("latitude");
            Longitude = xml.GetAttributeValue<double>("longitude");
            Accuracy = xml.GetAttributeValueAsInt32("accuracy");
            PlaceId = xml.GetAttributeValue("place_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="PhotosResultItem"/> from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="XElement"/> to parse.</param>
        /// <returns>An instance of <see cref="PhotosResultItem"/>.</returns>
        public static PhotosResultItem Parse(XElement xml) {
            return xml == null ? null : new PhotosResultItem(xml);
        }

        #endregion

    }

}