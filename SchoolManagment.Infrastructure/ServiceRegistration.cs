using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Helper;
using SchoolManagment.Infrastructure.Data;
using System.Text;

namespace SchoolManagment.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {


            #region Identity

            services.AddIdentity<ApplicationUser, Role>(option =>
            {
                // Password settings.
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 6;
                option.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;

                // User settings.
                option.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            #endregion


            #region JWT 
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
            #endregion

            //Swagger Gn
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Project", Version = "v1" });
                c.EnableAnnotations();

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
                 Array.Empty<string>()
             }
                });
            });

            services.AddAuthorization(option =>
            {
                option.AddPolicy(Policies.CreateStudent, policy =>
                {
                    // if current user has 'Create Student' claim so he has this policy,and so on
                    policy.RequireClaim("Create Student", "True");
                });
                option.AddPolicy(Policies.DeleteStudent, policy =>
                {
                    policy.RequireClaim("Delete Student", "True");
                });
                option.AddPolicy(Policies.EditStudent, policy =>
                {
                    policy.RequireClaim("Edit Student", "True");
                });
            });

            return services;
        }
    }


}
