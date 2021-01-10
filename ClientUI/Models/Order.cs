using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ClientUI.Models
{
    public class Order
    {
        public int id { get; set; }
        [DisplayName("Products")]
        public List<int> products { get; set; }
        [DisplayName("Address")]
        public string address { get; set; }
        [DisplayName("Delivery type")]
        public string deliveryType { get; set; }
        public int fk_User { get; set; }
    }
}
