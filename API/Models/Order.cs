using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Order
    {
        public int id { get; set; }
        public List<int> products { get; set; }
        public string address { get; set; }
        public string deliveryType { get; set; }
        public int fk_User { get; set; }

    }
}
