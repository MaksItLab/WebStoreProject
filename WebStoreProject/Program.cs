using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStoreProject.Infrastructure.Conventions;
//using WebStoreProject.Infrastructure.Middleware;
using WebStoreProject.Services;
using WebStoreProject.Services.InSQL;
using WebStoreProject.Services.Interfaces;

namespace WebStoreProject;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		var services = builder.Services;
		services.AddControllersWithViews(opt => {
			opt.Conventions.Add(new TestConvention());
		});

		services.AddDbContext<WebStoreDB>(opt => 
			opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
		services.AddTransient<IDbinitializer, DbInitializer>();

		services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
		//services.AddSingleton<IProductData, InMemoryProductData>();
		services.AddScoped<IProductData, SqlProductData>();
		
		


		var app = builder.Build();

		await using (var scope = app.Services.CreateAsyncScope()) { 
			var db_initializer = scope.ServiceProvider.GetRequiredService<IDbinitializer>();
			await db_initializer.InitializeAsync(RemoveBefore: false);
		}

		if (app.Environment.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseStaticFiles();

		//app.MapGet("/", () => "Inspect Endpoint.");

		app.Map("/testpath", context => context.Response.WriteAsync("test page"));

		app.UseRouting();

		app.UseWelcomePage("/welcome");

		//app.UseMiddleware<TestMiddleware>();


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