using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TripVolunteer.API.Controllers
{
    
    public class CheckClaimsAtt : Attribute, IAuthorizationFilter
    {

        private readonly string _claimName;
        private readonly string _claimValue;

        public CheckClaimsAtt(string claimName, string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.HasClaim(_claimName, _claimValue))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
