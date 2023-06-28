using System;
using System.Linq;

namespace KlaviyoSharp;

public class KlaviyoException : Exception
{
    public KlaviyoException(string message) : base(message) { }
    public KlaviyoException(Models.KlaviyoError error) : base(error?.Errors.FirstOrDefault()?.Detail)
    {
        InternalErrors = error?.Errors;
    }
    public Models.KlaviyoErrorDetails[] InternalErrors;
}