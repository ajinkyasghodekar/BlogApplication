using AutoMapper;
using BlogApi.Repository.IRepository;
using BlogApplication.DataAccess.Models;
using BlogApplication.DataAccess.Models.DTO.Blog;
using DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/BlogController")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _dbBlog;
        private readonly IMapper _mapper;
        public BlogController(IBlogRepository dbBlog, IMapper mapper)
        {
            _dbBlog = dbBlog;
            _mapper = mapper;
        }


        // Get all Blog [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDTO>>> GetBlogs()
        {
            IEnumerable<Blog> blogList = await _dbBlog.GetAllAsync();
            return Ok(_mapper.Map<List<BlogDTO>>(blogList));
        }


        // Create a Blog [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BlogDTO>> CreateBlog([FromBody] BlogCreateDTO blogCreateDTO)
        {
            Blog model = _mapper.Map<Blog>(blogCreateDTO);

            await _dbBlog.CreateAsync(model);
            return Ok(model);
        }


        // Delete a Blog [HttpDelete] based on Id
        [HttpDelete("{id:int}", Name = "DeleteBlog")]
        [Authorize(Roles ="admin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var blog = await _dbBlog.GetAsync(u => u.Id == id);
            if (blog == null)
            {
                return NotFound();

            }
            await _dbBlog.RemoveAsync(blog);
            return NoContent();
        }


        // Update a Blog Data [HttpPut] based on id
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateBlog(int id, [FromBody] BlogUpdateDTO blogUpdateDTO)
        {
            if (blogUpdateDTO == null || id != blogUpdateDTO.Id)
            {
                return BadRequest();
            }
            Blog model = _mapper.Map<Blog>(blogUpdateDTO);

            await _dbBlog.UpdateAsync(model);
            return NoContent();
        }
    }
}
