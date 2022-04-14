using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMicroservice.DBContext;
using UsersMicroservice.Model;

namespace UsersMicroservice.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public readonly UsersContext _dbContext;
        public UsersRepository(UsersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var user = _dbContext.Userses.Find(id);
            _dbContext.Userses.Remove(user);
            Save();
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _dbContext.Userses.ToList();
        }

        public Users GetuserById(int id)
        {
            return _dbContext.Userses.Find(id);

        }

        public void InsertUser(Users users)
        {
            _dbContext.Add(users);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Users users)
        {
            _dbContext.Entry(users).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
