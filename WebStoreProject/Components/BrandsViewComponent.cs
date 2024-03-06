using Microsoft.AspNetCore.Mvc;

namespace WebStoreProject.Components
{
	public class BrandsViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
