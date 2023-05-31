using BlogApplication.DataAccess.Models;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public IActionResult Create(Blog obj)
        {
            if(ModelState.IsValid)
            {
                _db.BlogsTable.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
