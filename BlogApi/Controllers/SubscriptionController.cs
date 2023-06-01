using AutoMapper;
using BlogApi.Repository.IRepository;
using BlogApplication.DataAccess.Models;
using BlogApplication.DataAccess.Models.DTO.Subscription;
using DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/SubscriptionController")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository _dbSubscription;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public SubscriptionController(ISubscriptionRepository dbSubscription, IMapper mapper)
        {
            _dbSubscription = dbSubscription;
            _mapper = mapper;
            this._response = new();
        }

        // Get all Subscription List data
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetSubscriptionLists()

        {
            try
            {

                IEnumerable<Subscription> subscriptionList = await _dbSubscription.GetAllAsync();

                _response.Result = _mapper.Map<List<SubscriptionDTO>>(subscriptionList);
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


        // Create a SubscriptionList [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateSubscription([FromBody] SubscriptionCreateDTO createDTO)
        {
            try
            {

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Subscription subscription = _mapper.Map<Subscription>(createDTO);

                await _dbSubscription.CreateAsync(subscription);
                _response.Result = _mapper.Map<SubscriptionDTO>(subscription);
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


        // Delete a Subscription [HttpDelete] based on Id
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<APIResponse>> DeleteSubscription(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var sub = await _dbSubscription.GetAsync(u => u.SubscriptionId == id);
                if (sub == null)
                {
                    return NotFound();
                }
                await _dbSubscription.RemoveAsync(sub);
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


        // Update a Subscription Data [HttpPut] based on id
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateSubscription(int id, [FromBody] SubscriptionUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.SubscriptionId)
                {
                    return BadRequest();
                }

                Subscription model = _mapper.Map<Subscription>(updateDTO);

                await _dbSubscription.UpdateAsync(model);
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
