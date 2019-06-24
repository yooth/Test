using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestProject.Domain.Models;
using TestProject.Domain.Services;
using TestProject.Extensions;
using TestProject.Resources;
using TestProject.Enquery;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> ListAsync([FromBody] CustomerEnquery enquery)
        {
            try
            {
                if (enquery == null)
                    return BadRequest("No inquiry data");
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                var customers = await _customerService.FindByAsync(enquery.CustomerId, enquery.Email);
                if (customers.Count() == 0)
                {
                    return Ok("Not Found");
                }

                var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
                return Ok(resources);
            }
            catch
            {
                return BadRequest(); 
            }

        }

    }
}
