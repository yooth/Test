using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Domain.Models;

namespace TestProject.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> FindByAsync(int id);
    }
}
