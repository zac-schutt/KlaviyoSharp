# KlaviyoSharp

KlaviyoSharp is a .NET 6.0 library that enables you to interact with the Klaviyo API in .NET. This project was started as there was no fully fleshed out and updated package available to interact with the Klaviyo API in .NET. **This project is still in development and is not ready for production use.** Version 1.0 will be released when all endpoints are implemented and tested.

## Installation

KlaviyoSharp is available on NuGet and is updated via CI/CD. To install KlaviyoSharp, run the following command in the Package Manager Console:

```powershell
Install-Package KlaviyoSharp
```

## API Support

Klaviyo's API is versioned by using dates in the request headers. The mapping of these to this package is as follows:

| Klaviyo API Version | KlaviyoSharp Version |
| ------------------- | -------------------- |
| 2023-06-15          | 1.0.x                |

## Endpoints

Endpoints are being developed from the [Klaviyo API Documentation](https://developers.klaviyo.com/en/reference/api_overview). A list of endpoints and their status can be found below.

- Accounts
  - [x] Accounts
- Campaigns
  - [ ] Campaigns
  - [ ] Messages
  - [ ] Jobs
  - [ ] Relationships
- Catalogs
  - [ ] Items
  - [ ] Variants
  - [ ] Categories
  - [ ] Relationships
- Client (Public facing API)
  - [x] Client
- Data Privacy
  - [x] Data Privacy
- Events
  - [ ] Events
- Flows
  - [ ] Flows
  - [ ] Relationships
- Lists
  - [x] Lists
  - [x] Relationships
- Metrics
  - [ ] Metrics
- Profiles
  - [ ] Profiles
  - [ ] Relationships
- Segments
  - [ ] Segments
  - [ ] Relationships
- Tags
  - [ ] Tags
  - [ ] Tag Groups
  - [ ] Relationships
- Templates
  - [ ] Templates

## Contributing

Checkout the [contributing](CONTRIBUTING.md) guide for more information on how to contribute to this project.

## Thankyou

Thanks to [@nozzlegear](https://github.com/nozzlegear) for the inspiration to create this package based roughly on his ShopifySharp package.
