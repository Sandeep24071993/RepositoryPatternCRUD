using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using RepositoryPatternCRUD.Data;
using RepositoryPatternCRUD.Models;
using RepositoryPatternCRUD.Repository.Interface;

namespace RepositoryPatternCRUD.Repository.Service
{
    public class UserRepository : IUser
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var datauser = await _context.Users.ToListAsync();
            return datauser;
        }
        public async Task<int> AddUser(User data)
        {
            await _context.Users.AddAsync(data);
            await _context.SaveChangesAsync();
            return data.UserId;
        }

        public async Task<User> UserGetById(int id)
        {
            var data = await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> UpdateRecard(User data)
        {
            bool status = false;
            if (data != null)
            {
                 _context.Users.Update(data);   
                 await _context.SaveChangesAsync(); 
                 status = true;
            }
            return status;  
        }

        public async Task<User> DetailsById(int id)
        {
            var data = await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            return data;
        }
            
        public async Task<bool> DeleteRecard(int id)
        {
            bool status = false;
            if (id != 0)
            {
               var data = await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
                if (data != null)
                {
                   _context.Users.Remove(data);
                    await _context.SaveChangesAsync();
                    status = true;  
                }
            }
            return status;
        }
    }
}
