using AutoMapper;
using BlogApplication.DataAccess.Models;
using BlogApplication.DataAccess.Models.DTO.Blog;
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
    }
}