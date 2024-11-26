using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Identity;
using Restaurant.Domain.Models;
using Restaurant.Repository.DBContext;
using Restaurant.Shared.DTOs.Orders;
using Restaurant.Shared.Resources;
using Restaurant.Web.Models;
using RestaurantWeb.Helpers;

namespace Restaurant.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IOrderService _service;

        public OrderController(IConfiguration configuration, IOrderService service)
            : base(configuration)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            try
            {
                var result = await _service.CreateAsync(createOrderDto);

                return Ok(ApiResult.SuccessResult(result));
            }
            catch(Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ApiResult.ErrorResult(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);

                return Ok(ApiResult.SuccessResult(result));
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ApiResult.ErrorResult(GlobalResource.GenericErrorMessage, ex.Message));
            }
        }
    }
}
