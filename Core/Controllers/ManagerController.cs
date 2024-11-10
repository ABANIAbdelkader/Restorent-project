using Core.Models;
using Core.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Core.UnitofWork;
using System.Security.Cryptography;
using NuGet.Protocol.Plugins;

namespace Core.Controllers
{
	public class ManagerController : Controller
	{
		public ManagerController(IUnitofWork myUnit)
		{
			_myUnit = myUnit;
		}

		private readonly IUnitofWork _myUnit;
		
		public IActionResult Index()
		{
			IEnumerable<Chef> chefs = _myUnit.chef.FindAll(o=>true);
			IEnumerable<Meal> meals= _myUnit.meal.FindAll(o => true);
			ViewBag.Chef = chefs;	
			ViewBag.Meal = meals;	
            return View();
		}
		[HttpGet]
       public IActionResult Login()
		{
			return View();
		}
	
		
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Login(Manager manager )
		{

    
			Manager mng = _myUnit.manager.FindAll(m => m.Card_Number == manager.Card_Number).FirstOrDefault();
			if(mng==null)
			{
				return View(mng);
			}
			CurrentManger.ThisManger = mng;
			return Redirect("Index");
		}

		[HttpGet]
        public IActionResult AddManager()
        {
            return View();
        }

		[HttpPost]
        public async Task<  IActionResult> AddManager( Manager manager)
        {
			if (ModelState.IsValid)
			{
				if(_myUnit.manager.add(manager))
				{
					return Redirect("Admins/Index");
				}
			}
            return View(manager);
        }
		[HttpGet]
		public  IActionResult RemoveManager()
		{
			return View();
		}
		[HttpDelete]
		public async Task< IActionResult> DeleteManager( Manager manager)
		{
            if (ModelState.IsValid)
            {
                if (_myUnit.manager.Delete(manager))
                {
                    return Redirect("Admins/Index");
                }
            }
            return View(manager);
        }
	
		public  IActionResult update()
		{
			return View();
		}
		[HttpDelete]
		public async Task< IActionResult> update( Manager manager)
		{
            if (ModelState.IsValid)
            {
                if (_myUnit.manager.update(manager))
                {
                    return Redirect("Admins/Index");
                }
            }
            return View(manager);
        }
		 

    }
}
