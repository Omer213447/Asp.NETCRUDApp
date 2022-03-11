using baba.Data;
using baba.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace baba.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DenemeDbContext _db;

        public CategoryController(DenemeDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.Category;
            return View(categories);
        }
        //GET-Create
        public IActionResult Create()
        {
            
            return View();
        }
        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        //GET-Edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.Category.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        //Post-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //GET-Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.Category.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        //Post-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int ? id)
        {
            var item = _db.Category.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            _db.Category.Remove(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
