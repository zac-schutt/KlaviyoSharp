using System;
using System.Linq;

namespace KlaviyoSharp;
/// <summary>
/// An exception thrown by the Klaviyo API
/// </summary>
public class KlaviyoException : Exception
{
    /// <summary>
    /// Creates a new KlaviyoException with the given message
    /// </summary>
    /// <param name="message"></param>
    public KlaviyoException(string message) : base(message) { }
    /// <summary>
    /// Creates a new KlaviyoException with the given KlaviyoError. Uses the message from the first error in the list.
    /// </summary>
    /// <param name="error"></param>
    public KlaviyoException(Models.KlaviyoError error) : base(error?.Errors.FirstOrDefault()?.Detail)
    {
        InternalErrors = error?.Errors;
    }
    /// <summary>
    /// The full list of errors returned by the Klaviyo API
    /// </summary>
    public Models.KlaviyoErrorDetails[] InternalErrors;
}