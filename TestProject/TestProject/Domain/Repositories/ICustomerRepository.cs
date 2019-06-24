using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Domain.Models;

namespace TestProject.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> FindByAsync(int? id,string email);
    }
}
