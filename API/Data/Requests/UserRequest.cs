using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Requests
{
    public class UserRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
