using System.Web;
using System.Net.Http;
using System.ServiceModel.Channels;
using Microsoft.Owin;

namespace TokenAuthMVC.Managers
{
    /// <summary>
    /// Token-based authentication for ASP .NET MVC REST web services.
    /// Copyright (c) 2015 Kory Becker
    /// http://primaryobjects.com/kory-becker
    /// License MIT
    /// </summary>
    public static class CommonManager
    {
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        private const string RequestHeader = "X-Forwarded-For";
        private const string OwinContext = "MS_OwinContext";


        public static string GetIP(HttpRequestBase request)
        {
            string ip = request.Headers[RequestHeader]; // AWS compatibility

            if (string.IsNullOrEmpty(ip))
            {
                ip = request.UserHostAddress;
            }

            return ip;
        }


        public static string GetIpForApi(HttpRequestMessage request)
        {
            // Web-hosting
            if (request.Properties.ContainsKey(HttpContext))
            {
                HttpContextWrapper ctx =
                    (HttpContextWrapper)request.Properties[HttpContext];
                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
            }

            // Self-hosting
            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                RemoteEndpointMessageProperty remoteEndpoint =
                    (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }

            // Self-hosting using Owin
            if (request.Properties.ContainsKey(OwinContext))
            {
                OwinContext owinContext = (OwinContext)request.Properties[OwinContext];
                if (owinContext != null)
                {
                    return owinContext.Request.RemoteIpAddress;
                }
            }

            return null;

        }
    }
}
