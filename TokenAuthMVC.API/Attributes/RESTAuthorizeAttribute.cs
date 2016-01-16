using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using TokenAuthMVC.Managers;
using SecurityManager = TokenAuthMVC.Managers.SecurityManager;

namespace TokenAuthMVC.API.Attributes
{
    public class RestAuthorizeAttribute : AuthorizeAttribute
    {
        private const string SecurityToken = "token";

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Authorize(actionContext))
            {
                return;
            }

            HandleUnauthorizedRequest(actionContext);
        }


        private bool Authorize(HttpActionContext actionContext)
        {
            try
            {
                HttpRequestMessage request = actionContext.Request;
                string token = request.GetQueryNameValuePairs().SingleOrDefault(v => v.Key == SecurityToken).Value;
                return SecurityManager.IsTokenValid(token, CommonManager.GetIpForApi(request), HttpContext.Current.Request.UserHostAddress);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}