using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WildBerries.Models
{
    public class EFDbContext : DbContext
    {
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Drink> Drinks { get; set; }
    }
}