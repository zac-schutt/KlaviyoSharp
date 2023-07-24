# Framework Target Differences

This package compiles for multiple frameworks. This document outlines the differences between the compiled code for each framework.

## [KlaviyoDateOnly.cs](../KlaviyoSharp/Infrastructure/KlaviyoDateOnly.cs)

NETStandard 2.0 does not contain the DateOnly type which is used in the Klaviyo API. This file contains a class that can be used in place of DateOnly. It contains implicit conversions to and from `System.DateOnly` for the NET 6.0 framework only.

## [QueryParams.cs](../KlaviyoSharp/Infrastructure/QueryParams.cs)

The `QueryParams` class is derived from a `Dictionary<string, string>`. The `TryAdd` method is not available on NETStandard 2.0 and is implemented in this file.

## [KlaviyoService.cs](../KlaviyoSharp/KlaviyoService.cs)

The `HTTP<T>` method uses the `ReadAsStringAsync` method on the `HttpContent` object. This method supports passing a `CancellationToken` on NET 6.0 only.
