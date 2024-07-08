using Microsoft.EntityFrameworkCore;
using RepositoryPatternCRUD.Models;
using RepositoryPatternCRUD.Repository.Interface;

namespace RepositoryPatternCRUD.Service
{
    public class UserService : IUserService
    {
        private readonly IUser _userService;
        public UserService(IUser userService)
        {
             _userService = userService; 
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
           return await _userService.GetUsers();
        }

        public async Task<int> AddUser(User data)
        {
            return await _userService.AddUser(data);
        }
        public async Task<User> UserGetById(int id)
        {
            return await _userService.UserGetById(id);
        }
        public async Task<bool> UpdateRecard(User data)
        {
            
            return await _userService.UpdateRecard(data);
        }
        public async Task<User> DetailsById(int id)
        {
            return await _userService.DetailsById(id);
        }

        public async Task<bool> DeleteRecard(int id)
        {
            return await _userService.DeleteRecard(id);
        }
    }
}
