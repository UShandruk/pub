using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildBerries.Models;
using WildBerries.SubmitModels;

namespace WildBerries.DAL
{
    public interface IDrinksRepository: IDisposable
    {
        IEnumerable<Drink> GetDrinks();

        void BuyDrink(DrinkSubmitModel model);
    }
}
