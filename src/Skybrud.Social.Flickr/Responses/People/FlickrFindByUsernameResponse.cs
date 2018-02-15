﻿using System;
using Skybrud.Social.Flickr.Models.People;
using Skybrud.Social.Http;

namespace Skybrud.Social.Flickr.Responses.People {

    public class FlickrFindByUsernameResponse : FlickrResponse<FlickrFindByUsernameResponseBody> {

        #region Constructors

        private FlickrFindByUsernameResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseXmlElement(response.Body, FlickrFindByUsernameResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FlickrFindByUsernameResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="FlickrFindByUsernameResponse"/>.</returns>
        public static FlickrFindByUsernameResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new FlickrFindByUsernameResponse(response);
        }

        #endregion
    
    }



}