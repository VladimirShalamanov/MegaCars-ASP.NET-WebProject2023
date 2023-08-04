namespace MegaCarsSystem.Web
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    using MegaCarsSystem.Data;
    using MegaCarsSystem.Data.Models;
    using MegaCarsSystem.Services.Data.Interfaces;
    using MegaCarsSystem.Web.Infrastructure.Extensions;
    using MegaCarsSystem.Web.Infrastructure.ModelBinders;

    using static Common.GeneralApplicationConstants;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<MegaCarsDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount =
                    builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

                options.Password.RequireLowercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");

                options.Password.RequireUppercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");

                options.Password.RequireNonAlphanumeric =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

                options.Password.RequiredLength =
                    builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<MegaCarsDbContext>();

            builder.Services.AddApplicationServices(typeof(ICarService));

            builder.Services.AddMemoryCache();

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
                cfg.AccessDeniedPath = "/Home/Error/401";
            });

            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.EnableOnlineUsersCheck();

            if (app.Environment.IsDevelopment())
            {
                app.SeedAdministrator(AdminEmail_Development);
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "ProtectingUrlPattern",
                    pattern: "/{controller}/{action}/{id}/{information}",
                    defaults: new { Controller = "Category", Action = "Details" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

            app.Run();
        }
    }
}