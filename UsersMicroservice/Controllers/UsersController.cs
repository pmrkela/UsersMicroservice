using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMicroservice.Repository;

using UsersMicroservice.Model;
using System.Transactions;

namespace UsersMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var UsersList = _usersRepository.GetAllUsers();

            return new OkObjectResult(UsersList);
        }


        [HttpGet("{id}",Name = "Get")]
        public IActionResult Get(int id)
        {
            var user = _usersRepository.GetuserById(id);
            return new OkObjectResult(user);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            using (var scope = new TransactionScope())
            {
                _usersRepository.InsertUser(user);
                 scope.Complete();
                 return CreatedAtAction(nameof(Get), new { id = user.id }, user);
            }
        }


        [HttpPut]
        public IActionResult Put([FromBody] Users user)
        {

            if(user != null)
            { 
                using (var scope = new TransactionScope())
                {
                    _usersRepository.Update(user);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            _usersRepository.Delete(id);
            return new OkResult();
        }



    }
}
