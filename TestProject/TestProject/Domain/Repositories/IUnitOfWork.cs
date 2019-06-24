using System.Threading.Tasks;

namespace TestProject.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}