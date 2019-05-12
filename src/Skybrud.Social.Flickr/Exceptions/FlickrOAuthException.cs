using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Social.Flickr.Exceptions {
    
    public class FlickrOAuthException : FlickrHttpException {

        #region Properties

        public string Problem { get; private set; }

        #endregion

        #region Constructors

        public FlickrOAuthException(IHttpResponse response) : base(response) {
            HttpQueryString body = HttpQueryString.ParseQueryString(response.Body);
            Problem = body["oauth_problem"] ?? "";
        }

        #endregion

    }

}