using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Flickr.Enums;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Flickr.Options.Photos {
    
    /// <summary>
    /// Class representing the options for uploading a photo.
    /// </summary>
    public class FlickrUploadPhotoOptions : IHttpPostOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the absolute path to the photo.
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Gets or sets the title of the photo.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the photo.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets an array of tags to apply to the photo.
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets the visibility of the photo.
        /// </summary>
        public FlickrPhotoSafetyVisibility Visibility { get; set; }

        /// <summary>
        /// Gets whether the photo should be visible to the public (default).
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets whether the photo should be visible to friends of the authenticated user.
        /// </summary>
        public bool IsFriend { get; set; }

        /// <summary>
        /// Gets whether the photo should be visible to family of the authenticated user.
        /// </summary>
        public bool IsFamily { get; set; }

        /// <summary>
        /// Gets or sets the safety level of the photo.
        /// </summary>
        public FlickrPhotoSafetyLevel SafetyLevel { get; set; }

        /// <summary>
        /// Gets or sets the content type of the photo.
        /// </summary>
        public FlickrPhotoContentType ContentType { get; set; }

        /// <summary>
        /// Gets or sets whether the photo should be hidden from public search results.
        /// </summary>
        public bool IsHidden { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public FlickrUploadPhotoOptions() {
            IsPublic = true;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {
            return new SocialHttpQueryString();
        }

        /// <summary>
        /// Gets an instance of <see cref="IHttpPostData"/> representing the POST parameters.
        /// </summary>
        public IHttpPostData GetPostData() {

            // Check wether a photo was specified
            if (String.IsNullOrWhiteSpace(Photo)) throw new PropertyNotSetException("Photo");

            SocialHttpPostData data = new SocialHttpPostData {
                IsMultipart = true
            };

            data.AddFile("photo", Photo);
            if (!String.IsNullOrWhiteSpace(Title)) data.Add("title", Title);
            if (!String.IsNullOrWhiteSpace(Description)) data.Add("description", Description);
            if (Tags != null && Tags.Length > 0) data.Add("tags", String.Join(" ", Tags));

            // Append the visiblity (if not private)
            switch (Visibility) {
                case FlickrPhotoSafetyVisibility.Public: {
                    data.Add("is_public", "1");
                    break;
                }
                case FlickrPhotoSafetyVisibility.Friends: {
                    data.Add("is_friend", "1");
                    break;
                }
                case FlickrPhotoSafetyVisibility.Family: {
                    data.Add("is_family", "1");
                    break;
                }
                case FlickrPhotoSafetyVisibility.FriendsAndFamily: {
                    data.Add("is_friend", "1");
                    data.Add("is_public", "1");
                    break;
                }
            }

            // Append the safety level (if specified)
            switch (SafetyLevel) {
                case FlickrPhotoSafetyLevel.Safe: data.Add("safety_level", "1"); break;
                case FlickrPhotoSafetyLevel.Moderate: data.Add("safety_level", "2"); break;
                case FlickrPhotoSafetyLevel.Restricted: data.Add("safety_level", "3"); break;
            }

            if (ContentType != FlickrPhotoContentType.NotSpecified) data.Add("content_type", (int)ContentType);
            
            if (IsHidden) data.Add("hidden", "2");

            return data;

        }

        #endregion

    }

}