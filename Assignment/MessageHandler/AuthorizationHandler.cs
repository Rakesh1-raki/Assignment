using System;

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Assignment.MessageAPIHandler
{
    public class AuthorizationHandler : DelegatingHandler
    {
        private const string APIKeyConfigured = "admin";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool validKey = false;
            IEnumerable<string> headerAPIkeyValues;
            var CheckApi = request.Headers.TryGetValues("ApiKey", out headerAPIkeyValues);
            if(CheckApi)
            {
                if(headerAPIkeyValues.FirstOrDefault().Equals(APIKeyConfigured))
                {
                    validKey = true;
                }
            }
            if(!validKey)
            {
                return request.CreateResponse(HttpStatusCode.Forbidden,"Invalid API key");
            }

            var response = await base.SendAsync(request, cancellationToken);
            return response;
           /* if (request.Headers.TryGetValues("X-ApiKey", out  headerAPIkeyValues))
            {
                var secretKey = headerAPIkeyValues;

                if (!string.IsNullOrEmpty((string)secretKey) && APIKeyConfigured.Equals(secretKey))
                {
                    return await base.SendAsync(request, cancellationToken);
                }
            }
            return request.CreateResponse(System.Net.HttpStatusCode.Forbidden, "API key is invalid.");*/
        }
    }
}