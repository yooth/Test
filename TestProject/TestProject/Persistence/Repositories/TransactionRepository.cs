using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.Domain.Models;
using TestProject.Domain.Repositories;
using TestProject.Persistence.Contexts;
using System.Linq;

namespace TestProject.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository , ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Transaction>> FindByAsync(int id)
        {
            return await _context.Transactions.Where(x => x.CustomerId.Equals(id))
                                 .ToListAsync();
        }
    }
}
