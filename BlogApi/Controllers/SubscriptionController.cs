using AutoMapper;
using BlogApi.Repository.IRepository;
using BlogApplication.DataAccess.Models;
using BlogApplication.DataAccess.Models.DTO.Subscription;
using DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/SubscriptionController")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository _dbSubscription;
        private readonly IMapper _mapper;
        public SubscriptionController(ISubscriptionRepository dbSubscription, IMapper mapper)
        {
            _dbSubscription = dbSubscription;
            _mapper = mapper;
        }


        // Get all Subscription [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionDTO>>> GetSubscriptions()
        {
            IEnumerable<Subscription> subscriptionList = await _dbSubscription.GetAllAsync();
            return Ok(_mapper.Map<List<SubscriptionDTO>>(subscriptionList));
        }


        // Create a Subscription [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SubscriptionDTO>> CreateSubscription([FromBody] SubscriptionCreateDTO subscriptionCreateDTO)
        {
            Subscription model = _mapper.Map<Subscription>(subscriptionCreateDTO);

            await _dbSubscription.CreateAsync(model);
            return Ok(model);
        }


        // Delete a Subscription [HttpDelete] based on Id
        [HttpDelete("{id:int}", Name = "DeleteSubscription")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var subscription = await _dbSubscription.GetAsync(u => u.SubscriptionId == id);
            if (subscription == null)
            {
                return NotFound();

            }
            await _dbSubscription.RemoveAsync(subscription);
            return NoContent();
        }


        // Update a Subscription Data [HttpPut] based on id
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateSubscription(int id, [FromBody] SubscriptionUpdateDTO subscriptionUpdateDTO)
        {
            if (subscriptionUpdateDTO == null || id != subscriptionUpdateDTO.SubscriptionId)
            {
                return BadRequest();
            }
            Subscription model = _mapper.Map<Subscription>(subscriptionUpdateDTO);

            await _dbSubscription.UpdateAsync(model);
            return NoContent();
        }
    }
}
