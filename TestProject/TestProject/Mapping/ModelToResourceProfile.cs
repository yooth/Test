using AutoMapper;
using TestProject.Domain.Models;
using TestProject.Extensions;
using TestProject.Resources;

namespace TestProject.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
			CreateMap<Customer, CustomerResource>();

            CreateMap<Transaction, TransactionResource>();
        }
    }
}