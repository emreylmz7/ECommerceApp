using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using OllieShop.IdentityServer.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OllieShop.IdentityServer.Services.UserServices
{
    public class CustomProfileService : IProfileService
    {
        // UserManager veya ihtiyacınıza göre başka bir bağımlılık ekleyebilirsiniz
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            // Kullanıcı bilgilerini al
            var user = await _userManager.GetUserAsync(context.Subject);

            // Kullanıcının rollerini al
            var roles = await _userManager.GetRolesAsync(user);

            // Role claim'lerini ekle
            var claims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            // Mevcut claim'leri ekle
            context.IssuedClaims.AddRange(claims);

            // Diğer gerekli claim'leri de ekleyebilirsiniz
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);
            context.IsActive = (user != null) && user.LockoutEnd == null;
        }
    }
}
