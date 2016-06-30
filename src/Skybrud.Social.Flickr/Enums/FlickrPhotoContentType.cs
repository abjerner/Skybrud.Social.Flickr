namespace Skybrud.Social.Flickr.Enums {
    
    /// <summary>
    /// Enum class indicating the type of a photo.
    /// </summary>
    public enum FlickrPhotoContentType {

        /// <summary>
        /// Indicates that the safety level hasn't been specified.
        /// </summary>
        NotSpecified = 0,

        /// <summary>
        /// Indicates that the file is a photo.
        /// </summary>
        Photo = 1,

        /// <summary>
        /// Indicates that the file is a screenshot.
        /// </summary>
        Screenshot = 2,

        /// <summary>
        /// Indicates that the file is neither <see cref="FlickrPhotoContentType.Photo"/> or <see cref="FlickrPhotoContentType.Screenshot"/>.
        /// </summary>
        Other = 3

    }

}