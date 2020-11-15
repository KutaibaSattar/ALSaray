using System.Collections.Generic;
using System.Threading.Tasks;
using ALSaray.Core;
using ALSaray.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ALSaray.Persistence
{

    public class ALSarayRepository : IALSarayRepository
    {
        private readonly MyDBContext _context;
        public ALSarayRepository(MyDBContext context)
        {
            _context = context;

        }

        public async Task<Purchase> GetPurchase(int id , bool includeRelated = true)
        {
           if (!includeRelated)
                return await _context.purchases.FindAsync(id);

           
            return await _context.purchases
            .Include(a => a.dbAcct)
            .Include(p => p.purchaseItems)
            .ThenInclude(pr => pr.Products)
            .SingleOrDefaultAsync(p => p.purchId == id);

           

        }

         public async Task<IEnumerable<Purchase>> GetPurchases()
        {
                     
            return await _context.purchases
            .Include(a => a.dbAcct)
            .Include(p => p.purchaseItems)
            .ThenInclude(pr => pr.Products)
            .ToListAsync();

           

        }

      



       /*  public async Task<Purchase> GetPurchaseWithSomething(int id)

        {
             return await _context.purchases
            .Include(a => a.dbAcct)
            .Include(p => p.purchaseItems)

        } */

        public void Add (Purchase purchase){

            _context.purchases.Add(purchase);

        }

        public void Remove(Purchase purchase)
        {
            _context.Remove(purchase);

        }


    }
}