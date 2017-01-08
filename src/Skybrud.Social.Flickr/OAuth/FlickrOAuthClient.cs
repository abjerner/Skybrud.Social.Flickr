using System;
using System.Collections.Specialized;
using Skybrud.Essentials.Common;
using Skybrud.Social.Flickr.Endpoints.Raw;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;
using Skybrud.Social.OAuth;
using Skybrud.Social.OAuth.Objects;
using Skybrud.Social.OAuth.Responses;

namespace Skybrud.Social.Flickr.OAuth {
    
    /// <summary>
    /// Class for handling the communication with the Flickr API. The class has methods for handling OAuth logins using
    /// a three-legged approach as well as logic for calling the methods decribed in the Flickr API (not all has been implemented yet).
    /// </summary>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/</cref>
    /// </see>
    /// <see>
    ///     <cref>https://www.flickr.com/services/api/auth.oauth.html</cref>
    /// </see>
    public class FlickrOAuthClient : SocialOAuthClient {

        #region Properties

        /// <summary>
        /// Gets a reference to the raw galleries endpoint.
        /// </summary>
        public FlickrGalleriesRawEndpoint Galleries { get; private set; }

        /// <summary>
        /// Gets a reference to the raw people endpoint.
        /// </summary>
        public FlickrPeopleRawEndpoint People { get; private set; }

        /// <summary>
        /// Gets a reference to the raw photosets endpoint.
        /// </summary>
        public FlickrPhotosetsRawEndpoint Photosets { get; private set; }

        /// <summary>
        /// Gets a reference to the raw photos endpoint.
        /// </summary>
        public FlickrPhotosRawEndpoint Photos { get; private set; }

        /// <summary>
        /// Gets a reference to the raw places endpoint.
        /// </summary>
        public FlickrPlacesRawEndpoint Places { get; private set; }

        /// <summary>
        /// Gets a reference to the raw test endpoint.
        /// </summary>
        public FlickrTestRawEndpoint Test { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FlickrOAuthClient"/> class with empty options.
        /// </summary>
        public FlickrOAuthClient() : this(null, null, null, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlickrOAuthClient"/> class with the specified
        /// <code>consumerKey</code> and <code>consumerSecret</code>.
        /// </summary>
        /// <param name="consumerKey">The comsumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        public FlickrOAuthClient(string consumerKey, string consumerSecret) : this(consumerKey, consumerSecret, null, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlickrOAuthClient"/> class.
        /// </summary>
        /// <param name="consumerKey">The comsumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        /// <param name="token">The access token of the user.</param>
        /// <param name="tokenSecret">The access token secret of the user.</param>
        public FlickrOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret) : this(consumerKey, consumerSecret, token, tokenSecret, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlickrOAuthClient"/> class.
        /// </summary>
        /// <param name="consumerKey">The comsumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        /// <param name="token">The access token of the user.</param>
        /// <param name="tokenSecret">The access token secret of the user.</param>
        /// <param name="callback">The callback URI used for authentication.</param>
        public FlickrOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret, string callback) {
        
            // Common properties
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Token = token;
            TokenSecret = tokenSecret;
            Callback = callback;

            // Specific to Flickr
            RequestTokenUrl = "https://www.flickr.com/services/oauth/request_token";
            AuthorizeUrl = "https://www.flickr.com/services/oauth/authorize";
            AccessTokenUrl = "https://www.flickr.com/services/oauth/access_token";

            // Initialize the raw endpoints
            Galleries = new FlickrGalleriesRawEndpoint(this);
            People = new FlickrPeopleRawEndpoint(this);
            Photosets = new FlickrPhotosetsRawEndpoint(this);
            Photos = new FlickrPhotosRawEndpoint(this);
            Places = new FlickrPlacesRawEndpoint(this);
            Test = new FlickrTestRawEndpoint(this);
        
        }

        #endregion

        public override SocialOAuthRequestTokenResponse GetRequestToken() {

            // Flickr apparently deviates from the OAuth 1.0a specification, since they require the OAuth properties to
            // be specified in the query string.

            // Some error checking
            if (RequestTokenUrl == null) throw new PropertyNotSetException("RequestTokenUrl");
            if (AuthorizeUrl == null) throw new PropertyNotSetException("AuthorizeUrl");
            if (ConsumerKey == null) throw new PropertyNotSetException("ConsumerKey");
            if (ConsumerSecret == null) throw new PropertyNotSetException("ConsumerSecret");
            if (Callback == null) throw new PropertyNotSetException("Callback");

            // Generate the OAuth signature
            string signature = GenerateSignature(SocialHttpMethod.Get, RequestTokenUrl, default(IHttpQueryString), null);

            // Append the OAuth properties to the query string
            NameValueCollection queryString = new NameValueCollection {
                {"oauth_nonce", Nonce},
                {"oauth_timestamp", Timestamp},
                {"oauth_consumer_key", ConsumerKey},
                {"oauth_signature_method", "HMAC-SHA1"},
                {"oauth_version", "1.0"},
                {"oauth_signature", signature},
                {"oauth_callback", Callback}
            };

            // Make the call to the API
            SocialHttpResponse response = SocialUtils.Http.DoHttpGetRequest(RequestTokenUrl, queryString);

            // Parse the response body
            SocialOAuthRequestToken body = SocialOAuthRequestToken.Parse(this, response.Body);

            // Parse the response
            return SocialOAuthRequestTokenResponse.ParseResponse(response, body);

        }

        public override SocialOAuthAccessTokenResponse GetAccessToken(string verifier) {

            // Flickr apparently deviates from the OAuth 1.0a specification, since they require the OAuth properties to
            // be specified in the query string.

            // Some error checking
            if (AccessTokenUrl == null) throw new PropertyNotSetException("AccessTokenUrl");
            if (ConsumerKey == null) throw new PropertyNotSetException("ConsumerKey");
            if (ConsumerSecret == null) throw new PropertyNotSetException("ConsumerSecret");
            if (Token == null) throw new PropertyNotSetException("Token");

            // Initialize the query string
            NameValueCollection queryString = new NameValueCollection { { "oauth_verifier", verifier } };

            // Generate the OAuth signature
            string signature = GenerateSignature(SocialHttpMethod.Get, AccessTokenUrl, queryString, null);

            // Append the OAuth properties to the query string
            queryString.Add("oauth_nonce", Nonce);
            queryString.Add("oauth_timestamp", Timestamp);
            queryString.Add("oauth_consumer_key", ConsumerKey);
            queryString.Add("oauth_signature_method", "HMAC-SHA1");
            queryString.Add("oauth_version", "1.0");
            queryString.Add("oauth_token", Token);
            if (!String.IsNullOrWhiteSpace(Callback)) queryString.Add("oauth_callback", Callback);
            queryString.Add("oauth_signature", signature);

            // Make the call to the API
            SocialHttpResponse response = SocialUtils.Http.DoHttpGetRequest(AccessTokenUrl, queryString);

            // Parse the response body
            SocialOAuthAccessToken body = SocialOAuthAccessToken.Parse(this, response.Body);

            // Parse the response
            return SocialOAuthAccessTokenResponse.ParseResponse(response, body);
        
        }

        /// <summary>
        /// Adds the OAuth 1.0a authorization header to the request
        /// </summary>
        /// <param name="request"></param>
        protected override void PrepareHttpRequest(SocialHttpRequest request) {

            // Skip OAuth 1.0a signed requests if no OAuth information is specified (this is a Flickr feature, not OAuth)
            if (String.IsNullOrWhiteSpace(ConsumerKey + ConsumerSecret + Token + TokenSecret)) return;

            // Sign requests using the logic in "SocialOAuthClient"
            base.PrepareHttpRequest(request);

        }
    
    }

}