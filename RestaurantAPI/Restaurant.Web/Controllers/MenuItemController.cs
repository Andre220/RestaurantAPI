using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Repository.DBContext;
using Restaurant.Shared.DTOs.MenuItems;
using Restaurant.Web.Models;
using RestaurantWeb.Helpers;

namespace Restaurant.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : BaseController
    {
        private readonly IMenuItemService _service;

        public MenuItemController(IConfiguration configuration, IMenuItemService service) 
            : base(configuration)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> List()
        {
            try
            {
                var result = await _service.ListAsync();

                return Ok(ApiResult.SuccessResult(result));
            }
            catch(Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ApiResult.ErrorResult(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDto>> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);

                return Ok(ApiResult.ErrorResult(result));
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ApiResult.ErrorResult(ex.Message));
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<MenuItemDto>> Create([FromBody] CreateMenuItemDTO createMenuItemDTO)
        {
            try
            {
                var result = await _service.CreateAsync(createMenuItemDTO);

                return Ok(ApiResult.SuccessResult(result));
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ApiResult.ErrorResult(ex.Message));
            }
        }

        [HttpPost("CreateMultiple")]
        public async Task<ActionResult<IEnumerable<CreateMenuItemDTO>>> CreateMultiple([FromBody] IEnumerable<CreateMenuItemDTO> createMenuItemsDTO)
        {
            try
            {
                var result = await _service.CreateMultipleAsync(createMenuItemsDTO);

                return Ok(ApiResult.SuccessResult(result));
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ApiResult.ErrorResult(ex.Message));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMenuItemDTO updateMenuItemDTO)
        {
            try
            {
                var result = await _service.UpdateAsync(updateMenuItemDTO);

                return Ok(ApiResult.ErrorResult(result));
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ApiResult.ErrorResult(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok(ApiResult.SuccessResult());
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ApiResult.ErrorResult(ex.Message));
            }
        }
    }

}