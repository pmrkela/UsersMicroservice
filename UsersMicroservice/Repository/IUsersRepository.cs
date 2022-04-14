using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMicroservice.Model;

namespace UsersMicroservice.Repository
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAllUsers();

        Users GetuserById(int id);

        void InsertUser(Users users);
        void Update(Users users);

        void Delete(int id);

        void Save();

    }
}
