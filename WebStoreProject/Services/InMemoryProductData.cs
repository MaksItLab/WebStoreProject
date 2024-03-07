using WebStoreProject.Data;
using WebStoreProject.Domain;
using WebStoreProject.Domain.Entities;
using WebStoreProject.Services.Interfaces;

namespace WebStoreProject.Services
{
	public class InMemoryProductData : IProductData
	{
		public IEnumerable<Brand> GetBrands() => TestData.Brands;

		public IEnumerable<Section> GetSections() => TestData.Sections;

		public IEnumerable<Product> GetProducts(ProductFilter? Filter = null)
		{
			IEnumerable<Product> query = TestData.Products;

			if (Filter?.SectionId != null)
				query = query.Where(p => p.SectionId == Filter.SectionId);

			if (Filter?.BrandId != null)
				query = query.Where(p => p.BrandId == Filter.SectionId);

			return query;
		}
	}
}
