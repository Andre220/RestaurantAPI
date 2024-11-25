using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Repository.DBContext;
using Restaurant.Shared.DTOs.Customers;
using RestaurantWeb.Helpers;

namespace Restaurant.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _service;

        public CustomerController(IConfiguration configuration, ICustomerService service)
            : base(configuration)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var result = await _service.ListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);

                if (result == null)
                {
                    return NotFound($"Customer with ID {id} not found.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDTO customerDTO)
        {
            try
            {
                var result = await _service.CreateAsync(customerDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDTO customerDTO)
        {
            try
            {
                var result = await _service.UpdateAsync(customerDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
