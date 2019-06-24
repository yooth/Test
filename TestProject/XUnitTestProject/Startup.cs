using Microsoft.Extensions.DependencyInjection;

using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;
using TestProject.Controllers.Config;
using TestProject.Domain.Repositories;
using TestProject.Domain.Services;
using TestProject.Persistence.Contexts;
using TestProject.Persistence.Repositories;
using TestProject.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

[assembly: TestFramework("XUnitTestProject.Startup", "XUnitTestProject")]
namespace XUnitTestProject
{
    public class Startup : DependencyInjectionTestFramework
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IMessageSink messageSink) : base(messageSink)
        {

            var builder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
            Configuration = builder.Build();
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddDbContext<AppDbContext>
          (options => options.UseSqlServer(Configuration.GetConnectionString("TestDatabase")));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddAutoMapper();
        }
    }
}
