using baba.Data;
using baba.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace baba.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly DenemeDbContext _db;

        public ApplicationTypeController(DenemeDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> applications = _db.ApplicationType;
            return View(applications);
        }
        //GET-Create
        public IActionResult Create()
        {
            return View();
        }
        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType application)
        {
            if (ModelState.IsValid)
            {
                _db.Add(application);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application);
        }
        //GET-Edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.ApplicationType.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        //POST-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType application)
        {
            if (ModelState.IsValid)
            {
                _db.Update(application);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        //GET-Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.ApplicationType.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        //POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var item = _db.ApplicationType.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            _db.Remove(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
