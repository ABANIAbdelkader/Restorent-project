using Core.Models;
using Core.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Razor;
using System.Linq.Expressions;

namespace Core.Controllers
{
	public class ChefController : Controller
	{
		private readonly IUnitofWork _myUnit;

		public ChefController(IUnitofWork myUnit)
		{
			_myUnit = myUnit;

		}
		
		public async Task<IActionResult> Index()
		{

            CurrentChef.TheChefislogin = true;
          var chefmeals=_myUnit.Chef_meal.FindAll(chm =>chm.chef_id==CurrentChef.ThisChef.id);
            var ordermeal = _myUnit.order_meal.FindAll(o => true).Join(_myUnit.meal.FindAll(o => true).Join(chefmeals, m => m.Id, orm => orm.meal_id, (m, chm) => new Meal("")
            {
                Id = m.Id,
                Name = m.Name,
                price = m.price,
                imagePath = m.imagePath,
                Description = m.Description,
              
                //clientfile = m.clientfile
            }), om => om.MealId, m => m.Id, (om,m)=>new Order_Meal {Id=om.Id,OrderId=om.OrderId,MealId=om.MealId,meal=m });
            return View(ordermeal);
		}
		[HttpGet]	
		public IActionResult Login ()
		{
			return View();
		}


		[HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Login (Chef chefdto )
        {
            Chef chef;
            if (chefdto != null)
            {
                 chef = _myUnit.chef.FindAll(om => true).SingleOrDefault(chef => chef.Card_Number == chefdto.Card_Number);
            }
            else return NotFound();
             if (chef != null)
            {
                if(chef.Card_Password==chefdto.Card_Password)
                { 
                    CurrentChef.ThisChef = chef;  
          
                    return RedirectToAction("Index");
                }
                else
                {
                     
                    return View(chef);
                }
            }
			return View(chefdto);
		}
       
		

     
        public IActionResult AddChef()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddChef(Chef chef)
        {
            if (ModelState.IsValid)
            {
                if (_myUnit.chef.add(chef))
                {
                    return Redirect("/Manager/Index");
                }
            }
            return View(chef);
        }
        [HttpGet]
        public IActionResult DeleteChef(int id )
        { 
            Chef chef=  _myUnit.chef.FindById(id);
            return View(chef);
        }
        [HttpPost]
        public IActionResult DeleteChef(Chef chef , string managerpassword)
        {
            if(CurrentManger.ThisManger.Card_Password!=managerpassword)
            {
                return View(chef); 
            }
            if (ModelState.IsValid)
            {
                if (  _myUnit.chef.Delete(chef))
                {
                    return Redirect("/Manager/Index");
                }
            }
            return View(chef);
        }

        public IActionResult update(int id )
        {
            Chef chef = _myUnit.chef.FindById(id);
            return View(chef);
        }
        [HttpPost]
        public async Task<IActionResult> update(Chef chef)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_myUnit.chef.update(chef))
                    {
                        return Redirect("/Manager/Index");
                    }
                }
                catch (Exception e)
                {
                    return NotFound();
                }
            }
            return View(chef);
        }


    }
}
