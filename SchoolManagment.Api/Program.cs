
using Microsoft.EntityFrameworkCore;
using SchoolManagment.Core.Middleware;
using SchoolManagment.Data;
using SchoolManagment.Infrastructure;
using SchoolManagment.Infrastructure.Data;
using SchoolManagment.Services;

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
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();
			app.UseMiddleware<ErrorHandlerMiddleware>();

			app.MapControllers();

			app.Run();
		}
	}
}
