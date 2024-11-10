using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Data;
using Core.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Core.Controllers
{
    public class MealsController : Controller
    {
        private readonly AppDbContext _context;

        public MealsController(AppDbContext context,IHostingEnvironment host)
        {
            _context = context;
            _host = host;
        }
        private readonly IHostingEnvironment _host;
        // GET: Meals


        // GET: Meals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.meals
                .Include(m => m.meal_chefs)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // GET: Meals/Create
        public IActionResult Create()
        {
            

            // إعداد ViewBag لتمرير قائمة الطهاة إلى الـ View
            ViewBag.chefs = new SelectList(_context.chefs, "id", "name");

            return View();
            
        }

        // POST: Meals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Meal meal, IFormFile clientfile,int chef_Id)
        {
            if (ModelState.IsValid)
            {
                string filename = string.Empty;
                if (clientfile != null)
                {
                    // تحديد مسار حفظ الصورة
                    string myupload = Path.Combine(_host.WebRootPath, "images");
                    filename = clientfile.FileName;

                    // إنشاء المسار الكامل للصورة
                    string fullpath = Path.Combine(myupload, filename);

                    // نسخ الملف إلى المجلد
                    using (var stream = new FileStream(fullpath, FileMode.Create))
                    {
                        await clientfile.CopyToAsync(stream);
                    }

                    // تعيين المسار إلى خاصية imagePath في الموديل
                    meal.imagePath = filename;
                }
                meal.meal_chefs = new List<chef_meal>() { new chef_meal { chef_id=chef_Id} };
                _context.meals.Add(meal);
            await _context.SaveChangesAsync();
                return Redirect("/Manager/Index");

            } // إضافة الوجبة إلى قاعدة البيانات

            // إعادة التوجيه إلى قائمة الوجبات
            return View(meal);
        }

                // GET: Meals/Edit/5
                public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.chefs = new SelectList(_context.chefs, "id", "name");


            var meal = await _context.meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            ViewData["Chef_id"] = new SelectList(_context.chefs, "id", "Adress", meal.meal_chefs);
            return View(meal);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Meal meal, IFormFile clientfile,int Chef_id)
        {
            if (ModelState.IsValid)
            {
                string filename = string.Empty;
                if (clientfile != null)
                {
                    // تحديد مسار حفظ الصورة
                    string myupload = Path.Combine(_host.WebRootPath, "images");
                    filename = clientfile.FileName;

                    // إنشاء المسار الكامل للصورة
                    string fullpath = Path.Combine(myupload, filename);

                    // نسخ الملف إلى المجلد
                    using (var stream = new FileStream(fullpath, FileMode.Create))
                    {
                        await clientfile.CopyToAsync(stream);
                    }

                    // تعيين المسار إلى خاصية imagePath في الموديل
                    meal.imagePath = filename;
                }
                meal.meal_chefs = new List<chef_meal> { new chef_meal { chef_id=Chef_id} };
                _context.Update(meal);
                await _context.SaveChangesAsync();
                return Redirect("/Manager/Index");

            } // إضافة الوجبة إلى قاعدة البيانات
ViewData["Chef_id"] = new SelectList(_context.chefs, "id", "Adress", meal.meal_chefs);
              // إعادة التوجيه إلى قائمة الوجبات
            return View(meal);
            
        }

        // GET: Meals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.meals
                .Include(m => m.meal_chefs)
               
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(Meal  meal)
        {
            if (ModelState.IsValid)
            {
                _context.meals.Remove(meal);
                _context.SaveChanges();
                return Redirect("/Manager/Index");
            }
            return View(meal);
        }
		
        private bool MealExists(int id)
        {
            return _context.meals.Any(e => e.Id == id);
        }
    }
}
