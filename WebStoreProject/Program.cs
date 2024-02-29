using Microsoft.AspNetCore.Mvc;
using WebStoreProject.Infrastructure.Conventions;
using WebStoreProject.Infrastructure.Middleware;
using WebStoreProject.Services;
using WebStoreProject.Services.Interfaces;

namespace WebStoreProject;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		var services = builder.Services;
		services.AddControllersWithViews(opt => {
			opt.Conventions.Add(new TestConvention());
		});

		services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();



		var app = builder.Build();


		if (app.Environment.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseStaticFiles();

		//app.MapGet("/", () => "Inspect Endpoint.");

		app.Map("/testpath", context => context.Response.WriteAsync("test page"));

		app.UseRouting();

		app.UseWelcomePage("/welcome");

		app.UseMiddleware<TestMiddleware>();


		app.MapGet("/hello/{name:alpha}", (string name) => $"Hello {name}!");
		app.MapGet("/throw", () =>
		{
			throw new ApplicationException("Ошибка");
		});

		app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

		app.MapControllerRoute("idk", "{controller=Home}/{action=FullEmployee}/{id?}");

		app.Run();
	}
}