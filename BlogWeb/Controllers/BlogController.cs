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

    }
}