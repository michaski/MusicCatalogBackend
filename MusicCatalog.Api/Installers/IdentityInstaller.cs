using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MusicCatalog.Domain.Entities;
using MusicCatalog.Infrastructure.Data;

namespace MusicCatalog.Api.Installers
{
    public class IdentityInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, IdentityRole>(opt =>
                {
                    opt.User.RequireUniqueEmail = true;
                    opt.SignIn.RequireConfirmedAccount = true;
                    opt.Password.RequireDigit = true;
                    opt.Password.RequireLowercase = true;
                    opt.Password.RequireUppercase = true;
                    opt.Password.RequireNonAlphanumeric = true;
                    opt.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<MusicCatalogDataContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = "Bearer";
                    opt.DefaultScheme = "Bearer";
                    opt.DefaultChallengeScheme = "Bearer";
                })
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = false;
                    opt.SaveToken = true;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Authentication:JwtSecretKey"])),
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidAudience = configuration["Authentication:JwtIssuer"],
                        ValidIssuer = configuration["Authentication:JwtIssuer"]
                    };
                    opt.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async ctx =>
                        {
                            var userManager = ctx.HttpContext.RequestServices
                                .GetRequiredService<UserManager<User>>();
                            var user = await userManager.FindByIdAsync(
                                ctx.Principal.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
                            if (user is not null && !user.IsActivated)
                            {
                                ctx.Fail("Konto nie zostało jeszcze aktywowane.");
                            }
                        }
                    };
                });

        }
    }
}
