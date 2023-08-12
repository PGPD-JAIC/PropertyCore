using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PropertyCore.WebUI.Services
{
    public class ClaimsLoader : IClaimsTransformation
    {
        
        public ClaimsLoader(IConfiguration configuration)
        {
            // pull Admin/Auth Users in from Config.
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = principal.Identities.FirstOrDefault(x => x.IsAuthenticated);
            if (identity == null) return principal;
            var user = identity.Name;
            if (user == null) return principal;
            if (principal.Identity is ClaimsIdentity identity1)
            {
                string logonName = user.Split('\\')[1];
                
                var ci = identity1;
                //foreach (UserRole userRole in userRoles)
                //{
                //    var c = new Claim(ci.RoleClaimType, userRole.Role.RoleTypeName);
                //    ci.AddClaim(c);
                //}
            }
            return principal;
        }
    }
}
