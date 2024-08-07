using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolManagment.Core.Middleware;
using SchoolManagment.Data;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Infrastructure;
using SchoolManagment.Infrastructure.Data;
using SchoolManagment.Infrastructure.Seeder;
using SchoolManagment.Services;
using Serilog;
using System.Globalization;

namespace SchoolManagment.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Remote"));
            });

            #region Serilog
            Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration).CreateLogger();
            builder.Services.AddSerilog();

            #endregion

            #region Dependency Injections
            builder.Services.AddInfrastructureDependencies(builder.Configuration)
                .AddServiceDependencies()
                .AddCoreDependencies()
                .AddServiceRegistration(builder.Configuration);

            //builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

            #endregion

            #region Localization
            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                     new CultureInfo("en-US"),
                     new CultureInfo("de-DE"),
                     new CultureInfo("fr-FR"),
                     new CultureInfo("ar-EG")
                };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            #endregion

            #region Cors
            var Cors = "_CORS";
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy(name: Cors,
                    policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                        policy.AllowAnyOrigin();
                    }
                );
            });

            #endregion

            builder.Services.AddDataProtection();


            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                await RoleSeeder.SeedAsync(roleManager);
                await UserSeeder.SeedAsync(userManager);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI();

            #region Localization Middleware
            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            #endregion

            app.UseHttpsRedirection();
            app.UseCors(Cors);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
