using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Assignment.Attributes
{
    public class ApiKeyValidationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if ((filterContext.HttpContext.Request.Headers["apikey"]!=null )&& (filterContext.HttpContext.Request.Headers["apikey"]=="Rakesh"))
            {
                return ;
            }
            else
            {
                
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
               

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            
            filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
        }
    }
}