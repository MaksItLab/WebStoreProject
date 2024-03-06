using WebStoreProject.Domain.Entities;

namespace WebStoreProject.Services.Interfaces
{
	public interface IProductData
	{
		IEnumerable<Section> GetSections ();
		IEnumerable<Brand> GetBrands ();
	}
}
