using System.Threading.Tasks;
using ALSaray.Core;
using ALSaray.Models;

namespace ALSaray.Persistence
{
    public class UnitOfWork : IUnitOfWork

    {


        private readonly MyDBContext _context;

        public UnitOfWork(MyDBContext context)
        {
            _context = context;
           
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}