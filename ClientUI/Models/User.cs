using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ClientUI.Models
{
    public class User
    {
        public int id { get; set; }
        [DisplayName("Email adress")]
        public string email { get; set; }
        [DisplayName("Password")]
        public string password { get; set; }
        public string role { get; set; }
    }
}
