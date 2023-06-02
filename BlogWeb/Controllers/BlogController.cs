using AutoMapper;
using DataAccess.Models;
using DataAccess.Models.DTO.Blog;
using BlogWeb.Services.IServices;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json;

namespace BlogWeb.Controllers
{

    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<BlogDTO> list = new();

            var response = await _blogService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BlogDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        // Create a new Blog 
        public async Task<IActionResult> CreateBlog()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBlog(BlogCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _blogService.CreateAsync<APIResponse>(model);
                if (response != null)
                {
                    TempData["success"] = "Blog Created Successfully !!!";
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(model);
        }


        public async Task<IActionResult> UpdateBlog(int BlogId)
        {
            var response = await _blogService.GetAsync<APIResponse>(BlogId);
            if (response != null)
            {
                BlogUpdateDTO model = JsonConvert.DeserializeObject<BlogUpdateDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBlog(BlogUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _blogService.UpdateAsync<APIResponse>(model);
                if (response != null)
                {
                    TempData["success"] = "Blog Updated Successfully !!!";
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(model);
        }

        public async Task<IActionResult> DeleteBlog(int BlogId)
        {
            var response = await _blogService.GetAsync<APIResponse>(BlogId);
            if (response != null)
            {
                BlogDTO model = JsonConvert.DeserializeObject<BlogDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBlog(BlogDTO model)
        {

            var response = await _blogService.DeleteAsync<APIResponse>(model.BlogId);
            if (response != null)
            {
                TempData["success"] = "Blog Deleted Successfully !!!";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}