using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MusicCatalog.Application.Services.UserContext;

namespace MusicCatalog.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.ApplicationAssembly));
            services.AddAutoMapper(AssemblyReference.ApplicationAssembly);
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(AssemblyReference.ApplicationAssembly);

            services.AddScoped<IUserContextService, UserContextService>();

            return services;
        }
    }
}
