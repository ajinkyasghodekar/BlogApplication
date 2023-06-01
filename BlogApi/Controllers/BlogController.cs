using AutoMapper;
using BlogApi.Repository.IRepository;
using BlogApplication.DataAccess.Models;
using BlogApplication.DataAccess.Models.DTO.Blog;
using DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/BlogController")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _dbBlog;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public BlogController(IBlogRepository dbBlog, IMapper mapper)
        {
            _dbBlog = dbBlog;
            _mapper = mapper;
            this._response = new();   
        }

        // Get all Blog List data
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetBlogs()

        {
            try
            {

                IEnumerable<Blog> blogList = await _dbBlog.GetAllAsync();

                _response.Result = _mapper.Map<List<BlogDTO>>(blogList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };

            }
            return _response;
        }


        // Create a Blog [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateBlog([FromBody] BlogCreateDTO createDTO)
        {
            try
            {

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Blog blog = _mapper.Map<Blog>(createDTO);

                await _dbBlog.CreateAsync(blog);
                _response.Result = _mapper.Map<BlogDTO>(blog);
                _response.StatusCode = HttpStatusCode.Created;
                return Ok();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        // Delete a Blog [HttpDelete] based on Id
        [Authorize(Roles ="admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<APIResponse>> DeleteBlog(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var blog = await _dbBlog.GetAsync(u => u.BlogId == id);
                if (blog == null)
                {
                    return NotFound();
                }
                await _dbBlog.RemoveAsync(blog);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        // Update a Blog Data [HttpPut] based on id
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateBlog(int id, [FromBody] BlogUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.BlogId)
                {
                    return BadRequest();
                }

                Blog model = _mapper.Map<Blog>(updateDTO);

                await _dbBlog.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
