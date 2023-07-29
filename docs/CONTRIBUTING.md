# Contributing Guide

If your interested in helping out with this project, please read the following guide before submitting a pull request. If you require clarification, please open an issue and ask.

## Changes Compatibility

This project tries to be relatively stable and I prefer to not introduce breaking changes unless absolutely necessary. If you are submitting a pull request that introduces a breaking change, please open an issue first to discuss the change.

In general, try to do one of the following instead of introducing a breaking change:

1. Mark properties `[Obsolete]` with an explination why before it's removed in a future release. Don't remove properties without warning.
1. If changing parameters of methods, add new method that overloads the existing method, and mark the old method `[Obsolete]`. If possible, attempt to re-map the old method to the new method.
1. If a service is removed from the API, without warning, increment the version of the package to reflect the breaking change.

## Adding Services

Services are linked to a sub-section of the Klaviyo API documentation. When adding a new service, all the methods provided on the service should be added. If a method is not yet implemented, it should be marked `[Obsolete]` with a message indicating that it is not yet implemented and should just throw a `NotImplementedException()`.

## Adding Models

Models should map to an object in the Klaviyo API. All properties should be nullable to prevent a default value being sent to the API.

## Adding Tests

All services **MUST** be added with tests. The tests should attempt to call all parts of the code that have been written. Multiple tests may need to be written for some methods to test different code paths. Tests are written in xUnit and should be added to the `Klaviyo.Tests` project. If you're using vscode as your code editor, you can use the snippet `new-test` to create a new test class.

## Testing Changes

Whatever you do, do not use your production account for testing. Testing this API will create a bunch of garbage data in your account. You can create a free account for testing purposes. See the [Klaviyo API documentation](https://developers.klaviyo.com/en/docs/create_a_test_account) for how to create a test account.

Changes should be able to be tested locally. To test your changes, you will need to copy the `appsettings.template.json` file to `appsettings.local.json` and fill in the values. You can then run the tests in your code editor. You can also provide the settings by setting the following environment variables:

- `KLAVIYO_APIKEY` - Private API key beginning with pk\_
- `KLAVIYO_COMPANYID` - 6 character company ID

### Account Config for Testing

The following are required for testing:

- The account is required to have a list called `Sample Data List`, and this list needs to have Single opt-in enabled in it's settings. This can't be set with the API, but is required for testing profile subscriptions.
- The account is required to have a flow. The welcome series flow is a great one for testing.

### Warning for PiHole Users

Testing with a PiHole DNS server will cause the tests to fail. This is because the PiHole blocks the request to the Klaviyo API. You can either disable the PiHole while testing, or add an exception for `a.klaviyo.com` to the PiHole. You'll know if this is the issue if you get a `HttpRequestException` with the message `The requested name is valid, but no data of the requested type was found`.

## Framework Targeting

This package targets both the NETStandard 2.0 and NET6.0 frameworks. This is because there are multiple Klaviyo fields that benefit from having the `DateOnly` class available. To maintain compatibility with older frameworks, the `KlaviyoDateOnly` class has been created with implicit conversions to and from `DateOnly`. This allows the `KlaviyoDateOnly` and `DateOnly` to be used interchangeably in client applications.

Any code that needs to be compiled only for one framework should be wrapped in a `#if NET6_0` block. This will allow the code to compile for both frameworks, but only be included in the NET6.0 build. A note should also be added to [FRAMEWORK-DIFFERENCES.md](FRAMEWORK-DIFFERENCES.md) for any differences in the code.

It should be rare that there are differences in the code used in the frameworks, and logic built on NetStandard 2.0 is always preferred.
