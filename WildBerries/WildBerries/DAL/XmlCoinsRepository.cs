using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml;
using WildBerries.Models;

namespace WildBerries.DAL
{
    public class XmlCoinsRepository : ICoinsRepository
    {
        public IEnumerable<Coin> GetCoins()
        {
            List<Coin> ListOfCoins = new List<Coin>();
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load("C:/Users/Chii/Desktop/WildBerries/WildBerries/WildBerries/Xml/Coins.xml");
            XmlElement xRoot = xDoc.DocumentElement;
                foreach(XmlElement xnode in xRoot)
                {
                    Coin coin = new Coin();
                    XmlNode attr = xnode.Attributes.GetNamedItem("id");
                    if (attr!=null)
                    coin.Id = Int32.Parse(attr.Value);

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "value")
                    coin.Value = Int32.Parse(childnode.InnerText);

                    if (childnode.Name == "isBlocked")
                    coin.IsBlocked = Boolean.Parse(childnode.InnerText);
                }
                ListOfCoins.Add(coin);
            }
            return ListOfCoins;
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }  
}