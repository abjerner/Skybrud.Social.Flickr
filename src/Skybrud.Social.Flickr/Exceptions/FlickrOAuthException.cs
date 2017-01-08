﻿using System.Collections.Specialized;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Exceptions {
    
    public class FlickrOAuthException : FlickrHttpException {

        #region Properties

        public string Problem { get; private set; }

        #endregion

        #region Constructors

        public FlickrOAuthException(SocialHttpResponse response) : base(response) {
            NameValueCollection body = SocialUtils.Misc.ParseQueryString(response.Body);
            Problem = body["oauth_problem"] ?? "";
        }

        #endregion

    }

}