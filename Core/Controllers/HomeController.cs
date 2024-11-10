using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Core.UnitofWork;

namespace Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger ,IUnitofWork myUnit)
        {
          

            
            _logger = logger;
            _myUnit = myUnit;
        }
        IUnitofWork _myUnit;
        public IActionResult Index()
        {
               if (CurrentOrder.ThisOrder==null)
            {
                ViewBag.Controller = "Orders";
                ViewBag.Action = "Create"; ViewBag.oorderid = -1;
            }
            else
            {
                ViewBag.Controller = "Order_Meal";
                ViewBag.Action = "Create";
                ViewBag.orderid=CurrentOrder.ThisOrder.Id;   
            }
            var meals = _myUnit.meal.FindAll(om=>true);
            return View(meals);
        }
        public IActionResult ManiPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
