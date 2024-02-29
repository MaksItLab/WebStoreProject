using Microsoft.AspNetCore.Mvc;
using WebStoreProject.Models;

namespace WebStoreProject.Controllers;

public class HomeController : Controller
{
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public string ShowStr([FromQuery]string a)
    {
        return $"HI! {a}";
    }


}