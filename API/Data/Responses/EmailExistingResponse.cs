using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Responses
{
    public class EmailExistingResponse
    {
        public User user { get; set; }
        public bool isExisting { get; set; }
    }
}
