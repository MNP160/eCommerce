using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommerceFrontend.Utility
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(params string[] claim) : base(typeof(AuthorizeFilter))
        {
            Arguments = new object[] { claim };
        }
    }

    public class AuthorizeFilter : IAuthorizationFilter
    {
        readonly string[] _claim;

        public AuthorizeFilter(params string[] claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAuthenticated = context.HttpContext.Request.Headers.ContainsKey("Authorization");

            if (isAuthenticated)
            {
                // I am sorry.
                // There was no other way.
                Microsoft.Extensions.Primitives.StringValues token;
                // Goes through all default headers and returns the value of "Authorization" -> saves to token
                var stream = context.HttpContext.Request.Headers.TryGetValue("Authorization", out token);
                var handler = new JwtSecurityTokenHandler();
                // Split the token since it is in format "Bearer {token}" -> only get token
                var jsonToken = handler.ReadToken(token.ToString().Split(' ')[1]);
                var tokenS = handler.ReadToken(token.ToString().Split(' ')[1]) as JwtSecurityToken;
                // Converting to string from StringValues means taht "role" is actually saved as "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                var role = tokenS.Claims.First(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;

                bool flagClaim = false;
                if (_claim.Contains(role))
                    flagClaim = true;

                if (!flagClaim)
                    context.Result = new RedirectResult("~/Dashboard/NoPermission");
            }
            else
            {
                context.Result = new RedirectResult("~/Home/Privacy");
            }
            return;
        }
    }
}
