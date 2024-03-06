using Microsoft.AspNetCore.Mvc;
using WebStoreProject.Services.Interfaces;

namespace WebStoreProject.Components
{
	
	public class SectionsViewComponent : ViewComponent
	{
		public readonly IProductData _ProductData;
        public SectionsViewComponent(IProductData ProductData) => _ProductData = ProductData;

        public IViewComponentResult Invoke()
		{
			var sections = _ProductData.GetSections();

			return View();
		}
	}
}
