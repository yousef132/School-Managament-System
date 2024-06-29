
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolManagment.Core.Middleware;
using SchoolManagment.Data;
using SchoolManagment.Infrastructure;
using SchoolManagment.Infrastructure.Data;
using SchoolManagment.Services;
using System.Globalization;

namespace SchoolManagment.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			#region Dependency Injections
			builder.Services.AddInfrastructureDependencies()
				.AddServiceDependencies()
				.AddCoreDependencies();

			#endregion

			#region Localization
			builder.Services.AddControllersWithViews();
			builder.Services.AddLocalization(opt =>
			{
				opt.ResourcesPath = "";
			});
			builder.Services.Configure<RequestLocalizationOptions>(opt =>
			{
				List<CultureInfo> locales = new List<CultureInfo>
				{
					new CultureInfo("en-US"),
					new CultureInfo("ar-EG")
				};
				opt.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
				opt.SupportedCultures = locales;
				opt.SupportedUICultures = locales;
			});



			#endregion
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			#region Localization Middleware

			var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
			app.UseRequestLocalization(options.Value);
			#endregion
			app.UseHttpsRedirection();

			app.UseAuthorization();
			app.UseMiddleware<ErrorHandlerMiddleware>();

			app.MapControllers();

			app.Run();
		}
	}
}
