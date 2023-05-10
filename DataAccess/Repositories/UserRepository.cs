using RestaurantAppBE.DataAccess.Context;
using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.RestServices.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAppBE.RestServices.Repositories
{
    public class UserRepository: IUserRepository
    {
        public IConfiguration _configuration;
        public readonly RestaurantAppContext _context;

        public UserRepository(IConfiguration configuration, RestaurantAppContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<User> GetUser(UserDto user)
        {
            var userFound = await _context.Users.FirstOrDefaultAsync(currentUser => currentUser.Email == user.Email);
            if (userFound == null)
            {
                return null;
            }
            else if (ComparePassword(user, userFound))
            {
                return userFound;
            }
            else
            {
                return null;
            }
        }

        public bool ComparePassword(UserDto user, User currentUser)
        {
            return BCrypt.Net.BCrypt.Verify(user.Password, currentUser.Password);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(currentUser => currentUser.UserId == id);
        }

        public async Task<int> RegisterUser(UserRegisterDto user)
        {
            await _context.Users.AddAsync(new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                type = user.type
            }); 
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateUser(UserRegisterDto user, int id)
        {
            var alreadyExistingUser =
                await _context.Users
                    .Where((currentUser) => currentUser.UserId == id)
                    .FirstOrDefaultAsync();

            if (alreadyExistingUser is not null)
            {
                alreadyExistingUser.Name = user.Name;
                alreadyExistingUser.Email = user.Email;
                alreadyExistingUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                alreadyExistingUser.type = user.type;

            }
            return await _context.SaveChangesAsync();
        }
    }
}
