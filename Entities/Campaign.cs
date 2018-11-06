using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Campaign
    {
        public string name { get; set; }
        public string description { get; set; }
        public string estado { get; set; }
        public DateTime finalDate { get; set; }
        public int id { get; set; }
        public string image { get; set; }
        public DateTime initialDate { get; set; }
        public int price { get; set; }
        public List<Producto> productCollection { get; set; }
    }
}