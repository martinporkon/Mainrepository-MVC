using System.Net;
using System.Net.Http;
using Sooduskorv_MVC.Aids.Events;
using Sooduskorv_MVC.Aids.Logging;

namespace Sooduskorv_MVC.Aids.HTTP
{
    public static class StatusCodes// Visitor pattern instead?
    {
        private static bool DoSomething(HttpStatusCode code)
        {
            switch (code)
            {
                case HttpStatusCode.NotFound:
                    break;
                case HttpStatusCode.Forbidden:
                    break;
                case HttpStatusCode.Continue:
                    break;
                case HttpStatusCode.SwitchingProtocols:
                    break;
                case HttpStatusCode.Processing:
                    break;
                case HttpStatusCode.EarlyHints:
                    break;
                case HttpStatusCode.OK:
                    break;
                case HttpStatusCode.Created:
                    break;
                case HttpStatusCode.Accepted:
                    break;
                case HttpStatusCode.NonAuthoritativeInformation:
                    break;
                case HttpStatusCode.NoContent:
                    break;
                case HttpStatusCode.ResetContent:
                    break;
                case HttpStatusCode.PartialContent:
                    break;
                case HttpStatusCode.MultiStatus:
                    break;
                case HttpStatusCode.AlreadyReported:
                    break;
                case HttpStatusCode.IMUsed:
                    break;
                case HttpStatusCode.Ambiguous:
                    break;
                case HttpStatusCode.Moved:
                    break;
                case HttpStatusCode.Found:
                    break;
                case HttpStatusCode.RedirectMethod:
                    break;
                case HttpStatusCode.NotModified:
                    break;
                case HttpStatusCode.UseProxy:
                    break;
                case HttpStatusCode.Unused:
                    break;
                case HttpStatusCode.RedirectKeepVerb:
                    break;
                case HttpStatusCode.PermanentRedirect:
                    break;
                case HttpStatusCode.BadRequest:
                    break;
                case HttpStatusCode.Unauthorized:
                    break;
                case HttpStatusCode.PaymentRequired:
                    break;
                case HttpStatusCode.MethodNotAllowed:
                    break;
                case HttpStatusCode.NotAcceptable:
                    break;
                case HttpStatusCode.ProxyAuthenticationRequired:
                    break;
                case HttpStatusCode.RequestTimeout:
                    break;
                case HttpStatusCode.Conflict:
                    break;
                case HttpStatusCode.Gone:
                    break;
                case HttpStatusCode.LengthRequired:
                    break;
                case HttpStatusCode.PreconditionFailed:
                    break;
                case HttpStatusCode.RequestEntityTooLarge:
                    break;
                case HttpStatusCode.RequestUriTooLong:
                    break;
                case HttpStatusCode.UnsupportedMediaType:
                    break;
                case HttpStatusCode.RequestedRangeNotSatisfiable:
                    break;
                case HttpStatusCode.ExpectationFailed:
                    break;
                case HttpStatusCode.MisdirectedRequest:
                    break;
                case HttpStatusCode.UnprocessableEntity:
                    break;
                case HttpStatusCode.Locked:
                    break;
                case HttpStatusCode.FailedDependency:
                    break;
                case HttpStatusCode.UpgradeRequired:
                    break;
                case HttpStatusCode.PreconditionRequired:
                    break;
                case HttpStatusCode.TooManyRequests:
                    break;
                case HttpStatusCode.RequestHeaderFieldsTooLarge:
                    break;
                case HttpStatusCode.UnavailableForLegalReasons:
                    break;
                case HttpStatusCode.InternalServerError:
                    break;
                case HttpStatusCode.NotImplemented:
                    break;
                case HttpStatusCode.BadGateway:
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    break;
                case HttpStatusCode.GatewayTimeout:
                    break;
                case HttpStatusCode.HttpVersionNotSupported:
                    break;
                case HttpStatusCode.VariantAlsoNegotiates:
                    break;
                case HttpStatusCode.InsufficientStorage:
                    break;
                case HttpStatusCode.LoopDetected:
                    break;
                case HttpStatusCode.NotExtended:
                    break;
                case HttpStatusCode.NetworkAuthenticationRequired:
                    break;
                default:
                    Log.Message(DataEvents.Exception.ToString());
                    return false;
            }
            return true;
        }
        public static bool Handle(HttpStatusCode httpStatusCode)
        {
            Log.Message(httpStatusCode.ToString());
            return DoSomething(httpStatusCode);
        }

        public static bool Handle(HttpStatusCode httpStatusCode, HttpResponseMessage responseMessage)
        {
            Log.Message($"{responseMessage.ReasonPhrase}");
            return DoSomething(httpStatusCode);
        }
    }
}