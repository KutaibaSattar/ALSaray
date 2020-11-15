using System.Threading.Tasks;

namespace ALSaray.Core
{
    public interface IUnitOfWork
    {

        Task CompleteAsync();

    }
}