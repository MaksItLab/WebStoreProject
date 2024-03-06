using WebStoreProject.Data;
using WebStoreProject.Domain.Entities;
using WebStoreProject.Services.Interfaces;

namespace WebStoreProject.Services
{
	public class InMemoryProductData : IProductData
	{
		public IEnumerable<Brand> GetBrands() => TestData.Brands;

		public IEnumerable<Section> GetSections() => TestData.Sections;
	}
}
