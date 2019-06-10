using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoreFitnessWebApp.Models
{
    public class ShoppingCart
    {
        [Key]
        [Column(Order = 1)]
        public int sessionID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int idProduct { get; set; }
        public string productName { get; set; }
        public int orderQty { get; set; }
    }
}