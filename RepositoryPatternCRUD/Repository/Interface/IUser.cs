using RepositoryPatternCRUD.Migrations;
using RepositoryPatternCRUD.Models;

namespace RepositoryPatternCRUD.Repository.Interface
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetUsers();
        Task<int> AddUser(User data);
        // void AddUser(User data);
        Task<User> UserGetById(int id);    
        Task<bool> UpdateRecard(User data);
        Task<User> DetailsById(int id);
        Task<bool> DeleteRecard(int id);
    }
}
