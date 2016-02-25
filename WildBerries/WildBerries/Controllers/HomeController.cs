using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WildBerries.DAL;
using WildBerries.Models;
using WildBerries.SubmitModels;

namespace WildBerries.Controllers
{
    public class HomeController : Controller
    {
        private ICoinsRepository repositoryCoins;
        private IDrinksRepository repositoryDrinks;
        public HomeController(ICoinsRepository coinsRepository, IDrinksRepository drinkRepository)
        {
            this.repositoryCoins = coinsRepository;            
            this.repositoryDrinks = drinkRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Coins()
        {
            return View(repositoryCoins.GetCoins().OrderBy(c=>c.Value));
        }        

        public ActionResult Drinks()
        {
            return View(repositoryDrinks.GetDrinks().Where(d => d.Quantity > 0).OrderBy(d => d.Price));
        }

        public ActionResult BuyDrink(DrinkSubmitModel model)
        {
            repositoryDrinks.BuyDrink(model);
            return View("Drinks", repositoryDrinks.GetDrinks().Where(d=>d.Quantity > 0).OrderBy(d=>d.Price));
        }
    }
}