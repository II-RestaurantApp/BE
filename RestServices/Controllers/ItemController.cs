﻿using RestaurantAppBE.DataAccess.DTOs;
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

        [HttpPost]
        public async Task<int?> RegisterItem([FromBody] ItemDto item)
        {
            return await _itemService.RegisterItem(item);
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
    }
}
