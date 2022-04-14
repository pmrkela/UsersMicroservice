using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersMicroservice.Model
{
    public class Users
    {
        public int id { get; set; }

        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
    }
}
