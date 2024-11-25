//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Restaurant.Application.Interfaces;
//using Restaurant.Domain.Models;
//using Restaurant.Repository.DBContext;
//using Restaurant.Shared.DTOs.OrderItems;
//using RestaurantWeb.Helpers;

//namespace Restaurant.Web.Controllers
//{
//    [Authorize]
//    [ApiController]
//    [Route("api/[controller]")]
//    public class OrderItemController : BaseController
//    {
//        private readonly IOrderItemService _service;

//        public OrderItemController(IConfiguration configuration, IOrderItemService service) 
//            :base(configuration)
//        {
//            _service = service;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<OrderItemDto>>> List()
//        {
//            try
//            {
//                var result = await _service.ListAsync();

//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                Log.LogError(ex.Message);
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<OrderItemDto>> GetById(Guid id)
//        {
//            var orderItem = await _context.OrderItems.FindAsync(id);

//            if (orderItem == null)
//            {
//                return NotFound($"OrderItem with ID {id} not found.");
//            }

//            return Ok(new OrderItemDto(orderItem.Id, orderItem.Quantity, orderItem.OrderId, orderItem.ItemId));
//        }

//        [HttpPost]
//        public async Task<ActionResult<OrderItemDto>> Create([FromBody] CreateOrderItemDTO createOrderItemDTO)
//        {
//            var orderExists = await _context.Orders.AnyAsync(o => o.Id == createOrderItemDTO.OrderId);
//            if (!orderExists)
//            {
//                return BadRequest("Invalid OrderId.");
//            }

//            var menuItemExists = await _context.MenuItems.AnyAsync(m => m.Id == createOrderItemDTO.ItemId);
//            if (!menuItemExists)
//            {
//                return BadRequest("Invalid ItemId.");
//            }

//            var orderItem = new OrderItem
//            {
//                Id = Guid.NewGuid(),
//                Quantity = createOrderItemDTO.Quantity,
//                OrderId = createOrderItemDTO.OrderId,
//                ItemId = createOrderItemDTO.ItemId
//            };

//            _context.OrderItems.Add(orderItem);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetById), new { id = orderItem.Id },
//                new OrderItemDto(orderItem.Id, orderItem.Quantity, orderItem.OrderId, orderItem.ItemId));
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderItemDTO updateOrderItemDTO)
//        {
//            if (id != updateOrderItemDTO.Id)
//            {
//                return BadRequest("OrderItem ID mismatch.");
//            }

//            var orderItem = await _context.OrderItems.FindAsync(id);
//            if (orderItem == null)
//            {
//                return NotFound($"OrderItem with ID {id} not found.");
//            }

//            orderItem.Quantity = updateOrderItemDTO.Quantity;

//            _context.Entry(orderItem).State = EntityState.Modified;
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(Guid id)
//        {
//            var orderItem = await _context.OrderItems.FindAsync(id);
//            if (orderItem == null)
//            {
//                return NotFound($"OrderItem with ID {id} not found.");
//            }

//            _context.OrderItems.Remove(orderItem);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }
//    }

//}
