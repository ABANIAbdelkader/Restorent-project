using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Data;
using Core.Models;

namespace Core.Controllers
{
    public class Order_MealController : Controller
    {
        private readonly AppDbContext _context;

        public Order_MealController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Order_Meal
      
        // GET: Order_Meal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Meal = await _context.order_Meals
               .FirstOrDefaultAsync(m => m.Id == id);
            order_Meal.meal=await _context.meals.SingleOrDefaultAsync(m=>m.Id== order_Meal.MealId); 
            if (order_Meal == null)
            {
                return NotFound();
            }

            return View(order_Meal);
        }

        // GET: Order_Meal/Create
        public IActionResult Create(int Mealid)
        {
            _context.order_Meals.Add(new Order_Meal { MealId=Mealid, OrderId=CurrentOrder.ThisOrder.Id  });
            _context.SaveChanges();
            return Redirect("/Orders/Index");
        }

        // POST: Order_Meal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
      
        // GET: Order_Meal/Edit/5
        
        // POST: Order_Meal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        // GET: Order_Meal/Delete/5
        public async Task<IActionResult> Delete(int? id,bool isorder=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Meal = await _context.order_Meals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order_Meal == null)
            {
                return NotFound();
            }
            _context.order_Meals.Remove(order_Meal);
            _context.SaveChanges();
            if (CurrentChef.TheChefislogin && isorder==false) { return Redirect("/Chef/Index"); }
            return Redirect("/Orders/Index");  
            
     }
    }
}
