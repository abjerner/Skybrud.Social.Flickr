using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Time;
using Skybrud.Social.Flickr.Enums;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Flickr.Options.Places {

    /// <summary>
    /// Class representing the options for a call to the <code>flickr.places.placesForContacts</code> Flickr API
    /// method.
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/flickr.places.placesForContacts.html</cref>
    /// </see>
    public class FlickrGetPlacesForContactsOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the place type to cluster photos by.
        /// </summary>
        public FlickrPlaceType PlaceType { get; set; }

        /// <summary>
        /// Optional: Gets or sets a Where on Earth identifier to use to filter photo clusters. For example all the
        /// photos clustered by <see cref="FlickrPlaceType.Locality"/> in the United States
        /// (WOE ID <code>23424977</code>).
        /// </summary>
        public string WoeId { get; set; }

        /// <summary>
        /// Gets or sets a Flickr Places identifier to use to filter photo clusters. For example all the photos
        /// clustered by <see cref="FlickrPlaceType.Locality"/> in the United States
        /// (Place ID <code>4KO02SibApitvSBieQ</code>).
        /// </summary>
        public string PlaceId { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of photos that a place type must have to be included. If the number of
        /// photos is lowered then the parent place type for that place will be used.
        /// 
        /// For example if your contacts only have 3 photos taken in the locality of Montreal (WOE ID 3534) but your
        /// threshold is set to 5 then those photos will be "rolled up" and included instead with a place record for
        /// the region of Quebec (WOE ID 2344924).
        /// </summary>
        public int Threshold { get; set; }

        /// <summary>
        /// Gets or sets the contacts mode. Either <see cref="FlickrContactsMode.All"/> or
        /// <see cref="FlickrContactsMode.FriendsAndFamily"/> for just friends and family.
        /// </summary>
        public FlickrContactsMode Contacts { get; set; }

        /// <summary>
        /// Gets or sets the minimum upload date. Photos with an upload date greater than or equal to this value will
        /// be returned.
        /// </summary>
        public EssentialsDateTime MinUploadDate { get; set; }

        /// <summary>
        /// Gets or sets the maximum upload date. Photos with an upload date less than or equal to this value will be
        /// returned.
        /// </summary>
        public EssentialsDateTime MaxUploadDate { get; set; }

        /// <summary>
        /// Gets or sets the minimum taken date. Photos with an taken date greater than or equal to this value will be
        /// returned.
        /// </summary>
        public EssentialsDateTime MinTakenDate { get; set; }

        /// <summary>
        /// Gets or sets the maximum taken date. Photos with an taken date less than or equal to this value will be
        /// returned.
        /// </summary>
        public EssentialsDateTime MaxTakenDate { get; set; }

        #endregion

        #region Member methods

        public IHttpQueryString GetQueryString() {

            // The place type must be specified
            if (PlaceType == FlickrPlaceType.Unknown) throw new PropertyNotSetException("PlaceType");

            // Either "WoeId" or "PlaceId" must be specified
            if (String.IsNullOrEmpty(WoeId + PlaceId)) throw new PropertyNotSetException("PlaceId");
            
            SocialHttpQueryString query = new SocialHttpQueryString();
            query.Add("method", "flickr.places.placesForContacts");
            query.Add("place_type_id", (int) PlaceType);
            if (!String.IsNullOrEmpty(WoeId)) query.Add("woe_id", WoeId);
            if (!String.IsNullOrEmpty(PlaceId)) query.Add("place_id", WoeId);
            if (Threshold > 0) query.Add("threshold", Threshold);
            query.Add("contacts", Contacts == FlickrContactsMode.FriendsAndFamily ? "ff" : "all");
            if (MinUploadDate != null) query.Add("min_upload_date", MinUploadDate.UnixTimestamp);
            if (MaxUploadDate != null) query.Add("max_upload_date", MaxUploadDate.UnixTimestamp);
            if (MinTakenDate != null) query.Add("min_taken_date", MinTakenDate.UnixTimestamp);
            if (MaxTakenDate != null) query.Add("max_taken_date", MaxTakenDate.UnixTimestamp);
            
            return query;
        
        }

        #endregion
    
    }

}