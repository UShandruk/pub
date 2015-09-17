using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsEngine.Models
{
    public class Person
    {
        public int id { get; set; } //переменная + get set = свойство. Предположение - Entity framework работает со свойствами и не работает с переменными
        public string name { get; set; }
        public int age { get; set; }
        public string place { get; set; }
    }
}