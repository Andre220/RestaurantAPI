﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Repository.DBContext;
using Restaurant.Shared.DTOs.MenuItems;
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
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> Get()
        {
            try
            {
                var result = await _service.ListAsync();

                return Ok(result);
            }
            catch(Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDto>> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MenuItemDto>> Create([FromBody] CreateMenuItemDTO createMenuItemDTO)
        {
            try
            {
                var result = await _service.CreateAsync(createMenuItemDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMenuItemDTO updateMenuItemDTO)
        {
            try
            {
                var result = await _service.UpdateAsync(updateMenuItemDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }

}