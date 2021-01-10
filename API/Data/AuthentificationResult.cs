using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class AuthentificationResult
    {
        public string token { get; set; }
        public bool success { get; set; }
        public IEnumerable<string> errors { get; set; }
    }
}
