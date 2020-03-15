using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WildBerries.Models;
using WildBerries.SubmitModels;

namespace WildBerries.DAL
{
    public class DbDrinksRepository : IDrinksRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Drink> GetDrinks()
        {
            return context.Drinks;
        }

        public void BuyDrink(DrinkSubmitModel model)
        {
            var drink = context.Drinks.FirstOrDefault(d => d.Id == model.Id);
            if (drink == null)
                return;

            drink.Quantity = drink.Quantity >= model.Quantity ? drink.Quantity - model.Quantity : 0;

            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}