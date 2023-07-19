# KlaviyoSharp

[![Build & Test](https://github.com/zac-schutt/KlaviyoSharp/actions/workflows/test.yml/badge.svg?branch=main)](https://github.com/zac-schutt/KlaviyoSharp/actions/workflows/test.yml)
![GitHub](https://img.shields.io/github/license/zac-schutt/KlaviyoSharp)
![GitHub issues](https://img.shields.io/github/issues/zac-schutt/KlaviyoSharp)
![GitHub last commit (branch)](https://img.shields.io/github/last-commit/zac-schutt/KlaviyoSharp/main)

![Nuget](https://img.shields.io/nuget/v/KlaviyoSharp)
![Nuget](https://img.shields.io/nuget/dt/KlaviyoSharp)

KlaviyoSharp is a .NET Standard 2.0 library that enables you to interact with the Klaviyo API in .NET. This project was started as there was no fully fleshed out and updated package available to interact with the Klaviyo API in .NET. **This project is still in development and is not ready for production use.** Version 1.0 will be released when all endpoints are implemented and tested.

## Installation

KlaviyoSharp is available on NuGet and is updated via CI/CD. To install KlaviyoSharp, run the following command in the Package Manager Console:

```powershell
Install-Package KlaviyoSharp
```

## API Support

Klaviyo's API is versioned by using dates in the request headers. The mapping of these to this package is as follows:

| Klaviyo API Version                                                                 | KlaviyoSharp Version |
| ----------------------------------------------------------------------------------- | -------------------- |
| [2023-06-15](https://developers.klaviyo.com/en/v2023-06-15/reference/api_overview)  | 1.0.x                |

## How to Use

```csharp
//Setup the config and client
var config = new KlaviyoConfig("Api-Key-Goes-Here");
var client = new KlaviyoAdminApi(config);

//You can also directly pass in the API key to the client
client = new KlaviyoAdminApi("Api-Key-Goes-Here");

//The public client doesn't use an API key, just a company ID
var publicClient = new KlaviyoClientApi("Company-ID-Goes-Here");

//Create filter for listing objects. Filters added to a FilterList are ANDed together.
var filter1 = new Filter(FilterOperation.Equals, "email", "test@example.com");
var filter2 = new Filter(FilterOperation.LessThan, "last_updated", DateOnly.Parse("2021-01-01"));
var filters = new FilterList() { filter1, filter2 };

//Retrieve profiles using the filter. All API calls are async.
var profiles = client.ProfileServices.GetProfiles(filter: filters, sort: "last_updated").Result;

//Returned lists are wrapped in a DataListObject class. The Data property contains the list of objects.
foreach (var profile in profiles.Data)
{
    Console.WriteLine(profile.Id);
}

//Create a new profile - Using the Create method sets the required default properties.
var newProfile = Profile.Create();
newProfile.Attributes = new()
{
    FirstName = "Test",
    LastName = "User",
    Email = "testing@example.com"
};
var createdProfile = client.ProfileServices.CreateProfile(newProfile).Result;

//Returned single items are wrapped in a DataObject class. The Data property contains the object.
Console.WriteLine(createdProfile.Data.Id);
```

## Contributing

Checkout the [contributing](CONTRIBUTING.md) guide for more information on how to contribute to this project.

## Thankyou

Thanks to [@nozzlegear](https://github.com/nozzlegear) for the inspiration to create this package based roughly on his ShopifySharp package.
