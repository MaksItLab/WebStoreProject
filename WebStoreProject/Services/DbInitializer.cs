using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStoreProject.Data;
using WebStoreProject.Services.Interfaces;

namespace WebStoreProject.Services
{
	public class DbInitializer : IDbinitializer
	{
		private readonly WebStoreDB _DB;
		private readonly ILogger<DbInitializer> _Logger;

        public DbInitializer(WebStoreDB db, ILogger<DbInitializer> Logger)
        {
			_DB = db;
			_Logger = Logger;
			
        }
        
		public async Task<bool> RemoveAsync(CancellationToken Cancel = default)
		{

			_Logger.LogInformation("Удаление БД...");
			var result = await _DB.Database.EnsureDeletedAsync(Cancel).ConfigureAwait(false);
			if (result)
				_Logger.LogInformation("Удаление БД прошло успешно");
			else
				_Logger.LogInformation("Удаление БД отсутствует");

			return result;
		}
			

		public async Task InitializeAsync(bool RemoveBefore = false, CancellationToken Cancel = default)
		{

			_Logger.LogInformation("Инициализация БД...");
			if (RemoveBefore)
				await RemoveAsync(Cancel).ConfigureAwait(false);

			//await _DB.Database.EnsureCreatedAsync();

			var pendidng_migrations = await _DB.Database.GetPendingMigrationsAsync(Cancel);
			if (pendidng_migrations.Any())
			{
				_Logger.LogInformation("Выполнение миграций БД...");
				await _DB.Database.MigrateAsync(Cancel).ConfigureAwait(false);
				_Logger.LogInformation("Миграция БД выполнено успешно");
			}

			
			await InitializeProductsAsync(Cancel).ConfigureAwait(false);

			_Logger.LogInformation("Инициализация БД выполнена успешно");
		}

		public async Task InitializeProductsAsync(CancellationToken Cancel)
		{
			if (_DB.Sections.Any()) {
				_Logger.LogInformation("Инициализация БД не требуется");
				return;
			}

			_Logger.LogInformation("Инициализация БД...");

			_Logger.LogInformation("Добавление секций в БД...");

			await using (await _DB.Database.BeginTransactionAsync()) 
			{
				await _DB.Sections.AddRangeAsync(TestData.Sections, Cancel);
				await _DB.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Sections] ON", Cancel);
				await _DB.SaveChangesAsync(Cancel);
				await _DB.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Sections] OFF", Cancel);
				await _DB.Database.CommitTransactionAsync(Cancel);
			}

			_Logger.LogInformation("Добавление брендов в БД...");
			await using (await _DB.Database.BeginTransactionAsync())
			{
				await _DB.Brands.AddRangeAsync(TestData.Brands, Cancel);
				await _DB.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Brands] ON", Cancel);
				await _DB.SaveChangesAsync(Cancel);
				await _DB.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Brands] OFF", Cancel);
				await _DB.Database.CommitTransactionAsync(Cancel);
			}

			_Logger.LogInformation("Добавление товаров в БД...");
			await using (await _DB.Database.BeginTransactionAsync())
			{
				await _DB.Products.AddRangeAsync(TestData.Products, Cancel);
				await _DB.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Products] ON", Cancel);
				await _DB.SaveChangesAsync(Cancel);
				await _DB.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Products] OFF", Cancel);
				await _DB.Database.CommitTransactionAsync(Cancel);
			}

			_Logger.LogInformation("Инициализация БД выполнена успешно");
		}
	}
}
