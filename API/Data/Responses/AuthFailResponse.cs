using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Responses
{
    public class AuthFailResponse
    {
        public IEnumerable<string> errors { get; set; }
    }
}
