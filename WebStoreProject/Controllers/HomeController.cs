using Microsoft.AspNetCore.Mvc;
using WebStoreProject.Models;
using WebStoreProject.Services.Interfaces;
using WebStoreProject.ViewModels;

namespace WebStoreProject.Controllers;

public class HomeController : Controller
{
    
    // GET
    public IActionResult Index([FromServices] IProductData ProductData)
    {
        var products = ProductData.GetProducts().Take(6)
            .OrderBy(p => p.Order)
            .Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
            });
        ViewBag.Products = products;
        return View();
    }

    public string ShowStr([FromQuery]string a)
    {
        return $"HI! {a}";
    }


}