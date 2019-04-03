using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S_cart.Models
{
    public class Purchase
    {
        public string purchaseid { get; set; }
        public string cartid { get; set; }
        public string productid { get; set; }
        public string activationcode { get; set; }
    }
}