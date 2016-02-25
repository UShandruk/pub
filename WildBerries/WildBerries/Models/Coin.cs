using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WildBerries.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public bool IsBlocked { get; set; }
    }
}