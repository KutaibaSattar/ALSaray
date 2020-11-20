using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALSaray.Core;
using ALSaray.Core.Models;
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

         public async Task<IEnumerable<Purchase>> GetPurchases(PurchaseQuery queryObj)
        {
                     
           /*  return await _context.purchases
            .Include(a => a.dbAcct)
            .Include(p => p.purchaseItems)
            .ThenInclude(pr => pr.Products)
            .ToListAsync(); */

          var query =  _context.purchases
            .Include(p => p.purchaseItems)
            .ThenInclude(pr => pr.Products)
            .Include(a => a.dbAcct).AsQueryable() ;
 
           
             
           //Expression<Func<Purchase,object>> exp ;
           //Dictionary<string, Expression <Func<Purchase,object>>> columnMap =  new Dictionary<string, Expression<Func<Purchase,object>>>();
            
            var  columnMap =  new Dictionary<string, Expression<Func<Purchase,object>>>()
            {
                    ["acct"] = pr => pr.dbAcct.acctName

            };

           // columnMap.Add("acct", pr => pr.dbAcct.acctName); old

       /*  if (queryObj.acctId.HasValue)
             query =  query.Where(pr => pr.accId == queryObj.acctId);

            if (queryObj.SortBy == "account")
                query = (queryObj.IsSortAscending) ? query.OrderBy(p => p.dbAcct.acctKey)
                 : query.OrderByDescending(p => p.dbAcct.acctKey); */

                 if (queryObj.IsSortAscending)
                    query = query.OrderBy(columnMap[queryObj.SortBy]);
                else
                    query = query.OrderByDescending(columnMap[queryObj.SortBy]);
            
             /*  //query =  query.Where(pr => pr.accId == 39); */

              return await query.ToListAsync();  



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