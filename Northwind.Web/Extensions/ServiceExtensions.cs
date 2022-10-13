using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Domain.Models;
using Northwind.Persistence;

namespace Northwind.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(o =>
            { 
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;


            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole),
              builder.Services);

            builder
                .AddEntityFrameworkStores<NorthwindContext>()
                .AddDefaultTokenProviders();
        }
    }
}
