using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Domain.Models;
using TestProject.Domain.Repositories;
using TestProject.Domain.Services;

namespace TestProject.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> FindByAsync(int? id, string email)
        {
            var customers = await _customerRepository.FindByAsync(id, email);
            foreach (var customer in customers) {
                customer.Transactions = await _transactionRepository.FindByAsync(customer.CustomerId); 
            }
            return customers;
        }
    }
}
