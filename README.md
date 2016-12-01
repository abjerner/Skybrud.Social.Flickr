Skybrud.Social.Flickr
=====================

### Installation

You can download this package from either NuGet (recommended) or download a ZIP file with the neccessary files from here on GitHub:

1. [**NuGet Package**][NuGetPackage]  
Install this NuGet package in your Visual Studio project. Makes updating easy.

2. [**ZIP file**][GitHubRelease]  
Grab a ZIP file of the latest release; unzip and move the files to the bin directory of your project.

### Found a bug? Have a question?

* Please feel free to [**create an issue**][Issues], and I will get back to you ;)

### Documentation

While there currently isn't any documentation available, you will be able to find it in the future at the [**Skybrud.Social website**][Website].

Meanwhile you can have a look at the examples below for getting started:

#### Usage

##### Initializing a new OAuth client

The `FlickrOAuthClient` class is responsible for the raw communication with the Flickr API as well as authentication. The class can be initialized with one of the constructors, or simply by setting the properties like in the examples below.

For accessing the Flickr API just on behalf of your app, you can initialize the `FlickrOAuthClient` class like:

```C#
// Initialize a new OAuth client with information about your app
FlickrOAuthClient oauth = new FlickrOAuthClient {
    ConsumerKey = "Your consumer key here",
    ConsumerSecret = "Your consumer secret here"
};
```

If you need to access parts of the API that requires user authentication, you should also specify the `Token` and `TokenSecret` properties (see the section about [Obtaining an access token](#obtaining-an-access-token)).

```C#
// Initialize and configure the OAuth client
FlickrOAuthClient client = new FlickrOAuthClient {
    ClientId = "Insert your client ID here",
    ClientSecret = "Insert your client secret here",
    Token = "The access token of the user",
    TokenSecret = "The access token secret of the user"
};
```

As part of OAuth 1.0a, the authentication requires that you specify a consumer key, consumer secret and a callback URL of your app (client). You can create a new app of find your existing apps using one of the links below:

* [**Create a new app** *at www.flickr.com*](https://www.flickr.com/services/apps/create/)
* [**Apps By You** *at www.flickr.com*](https://www.flickr.com/services/apps/by/me)


<br />
<br />
##### Generating the authorization URL / getting an authorization code

*Coming soon.*

<br />
<br />
##### Obtaining an access token

*Coming soon.*

<br />
<br />
##### Initializing an instance of FlickrService

The `FlickrService` class must be initialized from an instance of `FlickrOAuthClient`, since it is really this class that is responsible for making the calls to the API (`FlickrService` is merely a wrapper for the strongly typed implementation):

```C#
// Initialize a new OAuth client with information about your app (and the user)
FlickrOAuthClient client = new FlickrOAuthClient {
    ClientId = "Insert your client ID here",
    ClientSecret = "Insert your client secret here",
    Token = "The access token of the user",
    TokenSecret = "The access token secret of the user"
};

// Initialize a new service instance
FlickrService service = FlickrService.CreateFromOAuthClient(oauth);
```






[Website]: http://social.skybrud.dk/flickr/
[NuGetPackage]: https://www.nuget.org/packages/Skybrud.Social.Flickr/
[GitHubRelease]: https://github.com/abjerner/Skybrud.Social.Flickr/releases/latest
[Issues]: https://github.com/abjerner/Skybrud.Social.Flickr/issues
