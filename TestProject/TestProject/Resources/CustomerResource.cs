using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Domain.Models;

namespace TestProject.Resources
{
    public class CustomerResource
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
