# KlaviyoSharp

[![Build & Test](https://github.com/zac-schutt/KlaviyoSharp/actions/workflows/test.yml/badge.svg?branch=main)](https://github.com/zac-schutt/KlaviyoSharp/actions/workflows/test.yml)
![GitHub](https://img.shields.io/github/license/zac-schutt/KlaviyoSharp)
![GitHub issues](https://img.shields.io/github/issues/zac-schutt/KlaviyoSharp)
![GitHub last commit (branch)](https://img.shields.io/github/last-commit/zac-schutt/KlaviyoSharp/main)

![Nuget](https://img.shields.io/nuget/v/KlaviyoSharp)
![Nuget](https://img.shields.io/nuget/dt/KlaviyoSharp)

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
  - [x] Events
  - [x] Relationships
- Flows
  - [ ] Flows
  - [ ] Relationships
- Lists
  - [x] Lists
  - [x] Relationships
- Metrics
  - [x] Metrics
- Profiles
  - [x] Profiles
  - [x] Relationships
- Segments
  - [x] Segments
  - [x] Relationships
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
