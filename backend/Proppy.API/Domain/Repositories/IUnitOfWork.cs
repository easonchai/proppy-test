using System.Threading.Tasks;

namespace Proppy.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}