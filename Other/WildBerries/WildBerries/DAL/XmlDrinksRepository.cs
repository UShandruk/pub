using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using WildBerries.Models;
using WildBerries.SubmitModels;

namespace WildBerries.DAL
{
    public class XmlDrinksRepository : IDrinksRepository
    {
        public IEnumerable<Drink> GetDrinks()
        {
            List<Drink> ListOfDrinks = new List<Drink>();
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load("C:/Users/Chii/Desktop/WildBerries/WildBerries/WildBerries/Xml/Drinks.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                Drink drink = new Drink();
                XmlNode attr = xnode.Attributes.GetNamedItem("id");
                if (attr != null)
                    drink.Id = Int32.Parse(attr.Value);

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "name")
                        drink.Name = childnode.InnerText;

                    if (childnode.Name == "price")
                        drink.Price = Int32.Parse(childnode.InnerText);

                    if (childnode.Name == "quantity")
                        drink.Quantity = Int32.Parse(childnode.InnerText);
                }
                ListOfDrinks.Add(drink);
            }
            return ListOfDrinks;
        }

        public void BuyDrink(DrinkSubmitModel model)
        {
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}