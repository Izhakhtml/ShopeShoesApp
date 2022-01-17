using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopeShoesApp.Models
{
    public class SportShoe
    {
        public int id;
        public string companyName;
        public string modelName;
        public int size;
        public int price;

        public SportShoe(int id, string companyName, string modelName, int size, int price)
        {
            this.id = id;
            this.companyName = companyName;
            this.modelName = modelName;
            this.size = size;
            this.price = price;
        }
        public SportShoe() { }
    }
}