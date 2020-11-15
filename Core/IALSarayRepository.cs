using System.Collections.Generic;
using System.Threading.Tasks;
using ALSaray.Models;
using Microsoft.AspNetCore.Mvc;

namespace ALSaray.Core
{
    public interface IALSarayRepository
    {
        Task<Purchase> GetPurchase(int id, bool includeRelated = true);
        void Add(Purchase purchase);
    
        void Remove(Purchase purchase);
        Task<IEnumerable<Purchase>> GetPurchases();
    }
}