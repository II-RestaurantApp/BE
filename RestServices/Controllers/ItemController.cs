using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.RestServices.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace RestaurantAppBE.RestServices.Controllers
{
    [Route("item")]
    [ApiController]
    public class ItemController
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<Item> GetItem(int id)
        {
            return await _itemService.GetItemById(id);
        }

        [HttpGet]
        public async Task<List<Item>> GetItem()
        {
            return await _itemService.GetItem();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> RegisterItem([FromBody] ItemDto item)
        {
            await _itemService.RegisterItem(item);
            try
            {
                return new OkResult();
            }
            catch (BadHttpRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut]
        public async Task<IActionResult> UpdateItem([FromBody] ItemDto item, [FromQuery] int id)
        {
            await _itemService.UpdateItem(item, id);
            try
            {
                return new OkResult();
            }
            catch (BadHttpRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpDelete]
        [Route("{id:int}")]
        
        public async Task<int?> DeleteItem(int id)
        {
            return await _itemService.DeleteItem(id);
        }
    }
}
