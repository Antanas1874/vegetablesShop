using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ClientUI.Models
{
    public class AllOrders
    {
        public Order order { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
    }
}
