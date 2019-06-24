using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.Domain.Models;
using TestProject.Domain.Repositories;
using TestProject.Persistence.Contexts;
using System.Linq;

namespace TestProject.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Customer>> FindByAsync(int? id, string email)
        {
            return await _context.Customers.Where(x=>(x.CustomerId.Equals(id) || id == null) &&
                                                     (x.Email.Equals(email) || string.IsNullOrEmpty(email)))
                                 .ToListAsync();
        }
    }
}
