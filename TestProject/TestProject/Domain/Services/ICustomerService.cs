using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Domain.Models;

namespace TestProject.Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> FindByAsync(int? id, string email);
    }
}
