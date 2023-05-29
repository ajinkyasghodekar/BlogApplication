using AutoMapper;
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
        private readonly MyAppDb _db;
        private readonly IMapper _mapper;
        public BlogController(MyAppDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        // Get all User [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDTO>>> GetUsers()
        {
            IEnumerable<Blog> userList = await _db.BlogsTable.ToListAsync();
            return Ok(_mapper.Map<List<BlogDTO>>(userList));
        }

        // Create a Blog [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BlogDTO>> CreateUser([FromBody] BlogCreateDTO blogCreateDTO)
        {
            
            Blog model = _mapper.Map<Blog>(blogCreateDTO);

            await _db.BlogsTable.AddAsync(model);
            await _db.SaveChangesAsync();

            return Ok(blogCreateDTO);
        }

        // Delete a Blog [HttpDelete] based on Id
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = await _db.BlogsTable.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();

            }
            _db.BlogsTable.Remove(user);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // Update a Blog Data [HttpPut] based on id
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] BlogUpdateDTO blogUpdateDTO)
        {
            if (blogUpdateDTO == null || id != blogUpdateDTO.Id)
            {
                return BadRequest();
            }
            Blog model = _mapper.Map<Blog>(blogUpdateDTO);

            _db.BlogsTable.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
