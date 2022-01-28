using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Assignment.Models
{
    public class ApiProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //return base.ValidateClientAuthentication(context);
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // return base.GrantResourceOwnerCredentials(context);
            using (EmployeeRepository _rep = new EmployeeRepository())
            {
                var emp = _rep.ValidateEmployee(context.UserName, context.Password);
                if (emp == null)
                {
                    context.SetError("Invalid_grant", "Provided username and password is incorrect");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, emp.Desgination));
                identity.AddClaim(new Claim(ClaimTypes.Name, emp.FirstName));
                context.Validated(identity);

            }
        }
    }
}