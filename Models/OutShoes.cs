using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopeShoesApp.Models
{
    public class OutShoes
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Gender { get; set; }
        public bool IfThereIsHeel { get; set; }
        public bool IfThereIsInStock { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
    }
}