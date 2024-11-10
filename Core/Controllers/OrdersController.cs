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
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index(Order order )  
        {
            int Orderid = CurrentOrder.ThisOrder.Id ;
            
            ViewBag.orderId= Orderid;
			// List<Meal>    meals = _context.meals.Include(m => m.orders_meal).Where(mo => mo.orders_meal.First(orm=> orm.MealId==).OrderId == order.Id).ToList();
		//IEnumerable<Meal>  meals =await _context.order_Meals.Join (_context.meals, om => om.MealId, m => m.Id , (mid,m)=>new {meal=m,ord_meal=mid }).
       //       Join( _context.orders, mom=>mom.ord_meal.OrderId,o=>o.Id, (mom,o)=>new {orderid=o.Id ,meal=mom.meal})
       //      .Where(O_M=>O_M.orderid == Orderid).Select (m=>m.meal).Include(o=>o.orders_meal).ToListAsync();
          IEnumerable<Order_Meal> ordermeal=  await _context.order_Meals.Include(om=>om.meal).Where(om=> om.OrderId==Orderid).ToListAsync();
            int totalprice= 0;
            foreach(Order_Meal item in ordermeal)
            {
                totalprice +=item.meal.price ;
            }
            TempData["totalprice"]=totalprice;
            return View(ordermeal );
        }
// GET: Orders/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create(int Mealid)
        {
            ViewBag.mealid = Mealid;
         

            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Order orderdto,int mealid)
        {
            if (ModelState.IsValid)
            {
                  if (!_context.orders.Any(o => o.Name == orderdto.Name && o.phonenumber == orderdto.phonenumber))
                {
                    _context.orders.Add(orderdto); await _context.SaveChangesAsync();

                }
                Order order = _context.orders.FirstOrDefault(o => o.Name == orderdto.Name&&o.phonenumber==orderdto.phonenumber);


                if (order != null) {
                    CurrentOrder.ThisOrder = order;

                    if( mealid!=0)
                {
                    
                Order_Meal ordermeal=new Order_Meal() {OrderId=order.Id,MealId=mealid};
                _context.order_Meals.Add(ordermeal);
                await _context.SaveChangesAsync();
            }}
     return RedirectToAction(nameof(Index), order); 
            }
            return View ( orderdto );
        }

    

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
      
        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete()
        {

            return View();
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.orders.FindAsync(id);
            if (order != null)
            {
                _context.orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.orders.Any(e => e.Id == id);
        }
    }
}
