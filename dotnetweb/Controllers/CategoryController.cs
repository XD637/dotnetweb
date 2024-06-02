using Microsoft.AspNetCore.Mvc;
using dotnetweb.Models;
using dotnetweb.Data;

namespace dotnetweb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDBcontext _db;
        public CategoryController(AppDBcontext db)
        {
            _db = db;
                
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //get
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.User == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("user", "The DisplayOrder cannot be same as User.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created sucessfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id = id);
            //var categoryFromDbFirst = _db.Categories.SingleOrDefault(u => u.Id = id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.User == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("user", "The DisplayOrder cannot be same as User.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated sucessfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id = id);
            //var categoryFromDbFirst = _db.Categories.SingleOrDefault(u => u.Id = id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted sucessfully.";
            return RedirectToAction("Index");

        }
    }
}
