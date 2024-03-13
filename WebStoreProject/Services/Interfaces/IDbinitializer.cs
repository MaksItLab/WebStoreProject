namespace WebStoreProject.Services.Interfaces
{
	public interface IDbinitializer
	{
		Task<bool> RemoveAsync(CancellationToken Cancel = default);
		Task InitializeAsync(bool RemoveBefore = false, CancellationToken Cancel = default);
	}
}
