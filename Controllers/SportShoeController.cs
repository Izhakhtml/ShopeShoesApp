using ShopeShoesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopeShoesApp.Controllers.api
{
    public class SportShoeController : Controller
    {
        // GET: SportShoe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PresentNameModelSportShoe()
        {
            return View(SportShoes());
        }
        public ActionResult PresentModelSportShoe(int id)
        {
            foreach(var item in SportShoes())
            {
                if(item.id == id)
                {
                  return View(item);
                }
            }
            return View();
        }
        public ActionResult PresentModelSportShoes()
        {
            return View(SportShoes());
        }
        public SportShoe[] SportShoes()
        {
            SportShoe[] sportShoesArray = new SportShoe[]
            {
                new SportShoe(1,"NIKE","HEIGTH",43,400),
                new SportShoe(2,"ADIDAS","SHORT",40,300),
                new SportShoe(3,"PUMA","OPEN",41,350),
                new SportShoe(4,"DIADORA","CLOSE",39,450)
            };
            return sportShoesArray;
        }
    }
}