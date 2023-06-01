using BlogApplication.DataAccess.Models;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BlogWeb.Controllers
{

    public class BlogController : Controller
    {
        private readonly MyAppDb _db;
        public BlogController(MyAppDb db)
        {
            _db = db;
        }


        // View all blogs in UI
        public IActionResult Index()
        {
            List<Blog> blogList = _db.BlogsTable.ToList();
            return View(blogList);
        }


        // Create a blog in UI
        public IActionResult CreateBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBlog(Blog obj)
        {  
                _db.BlogsTable.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");           
        }


        // Edit a blog in UI
        public IActionResult EditBlog(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Blog? blogFromDb = _db.BlogsTable.Find(id);

            if (blogFromDb == null)
            {
                return NotFound();
            }
            return View(blogFromDb);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog obj)
        {
            if (ModelState.IsValid)
            {
                _db.BlogsTable.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        // Edit a blog in UI
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Blog? blogFromDb = _db.BlogsTable.Find(id);

            if (blogFromDb == null)
            {
                return NotFound();
            }
            return View(blogFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Blog? obj = _db.BlogsTable.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.BlogsTable.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}