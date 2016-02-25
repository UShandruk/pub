using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WildBerries.Models;
using WildBerries.SubmitModels;

namespace WildBerries.DAL
{
    public class DbCoinsRepository : ICoinsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Coin> GetCoins()
        {
            return context.Coins;
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