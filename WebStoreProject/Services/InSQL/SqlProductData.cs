using WebStore.DAL.Context;
using WebStoreProject.Domain;
using WebStoreProject.Domain.Entities;
using WebStoreProject.Services.Interfaces;

namespace WebStoreProject.Services.InSQL
{
	public class SqlProductData : IProductData
	{
		private readonly WebStoreDB _DB;

		public SqlProductData(WebStoreDB DB)
        {
			_DB = DB;
        }
		public IEnumerable<Brand> GetBrands() => _DB.Brands;

		public IEnumerable<Product> GetProducts(ProductFilter? productFilter = null)
		{
			IQueryable<Product> query = _DB.Products;

			if (productFilter?.SectionId is { } section_id)
				query = query.Where(p => p.SectionId == section_id);

			if (productFilter?.BrandId is { } brand_id)
				query = query.Where(p => p.BrandId == brand_id);

			return query;
		} 

		public IEnumerable<Section> GetSections() => _DB.Sections;
	}
}
