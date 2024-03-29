﻿using Microsoft.AspNetCore.Mvc;
using WebStoreProject.Domain;
using WebStoreProject.Services.Interfaces;
using WebStoreProject.ViewModels;

namespace WebStoreProject.Controllers
{
	public class CatalogController : Controller
	{
		private readonly IProductData _ProductData;

		public CatalogController(IProductData ProductData)
        {
			_ProductData = ProductData;
		} 
        public IActionResult Index(int? BrandId, int? SectionId)
		{
			var filter = new ProductFilter
			{
				BrandId = BrandId,
				SectionId = SectionId,
			};

			var products = _ProductData.GetProducts(filter);

			var catalog_model = new CatalogViewModel
			{
				BrandId = BrandId,
				SectionId = SectionId,
				Products = products
					.OrderBy(p => p.Order)
					.Select(p => new ProductViewModel {
						Id = p.Id,
						Name = p.Name,
						ImageUrl = p.ImageUrl,
						Price = p.Price,
					})
			};

			return View(catalog_model);
		}
	}
}
