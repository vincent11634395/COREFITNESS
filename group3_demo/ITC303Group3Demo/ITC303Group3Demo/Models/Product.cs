using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITC303Group3Demo.Models
{
    public class Product
    {
        public int idProduct { get; set; }
        public string productName { get; set; }
        public string productDesc { get; set; }
        public double productPrice { get; set; }
        public string productAvailability { get; set; }
        public string productImg { get; set; }

    }
}