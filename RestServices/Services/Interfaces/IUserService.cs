﻿using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(UserDto user);
        Task<User> GetUserById(int id);
        Task<int?> RegisterUser(UserRegisterDto user);
    }
}
