using RepositoryPatternCRUD.Models;

namespace RepositoryPatternCRUD.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<int> AddUser(User data);
        Task<User> UserGetById(int id);
        Task<bool> UpdateRecard(User data);
        Task<User> DetailsById(int id);
        Task<bool> DeleteRecard(int id);
    }
}
