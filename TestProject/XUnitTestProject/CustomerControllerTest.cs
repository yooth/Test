using System;
using System.Collections.Generic;
using Xunit;
using AutoMapper;
using TestProject.Controllers;
using TestProject.Domain.Services;
using TestProject.Services;
using TestProject.Mapping;
using TestProject.Enquery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace XUnitTestProject
{
    public class CustomerControllerTest
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerControllerTest(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [Fact]
        public void Get_WhenCalled_WithNoInquery()
        {
            CustomersController _controller = new CustomersController(_customerService, _mapper);

            // Act
            var result = _controller.ListAsync(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);

        }

        [Fact]
        public void Get_WhenCalled_WithInqueryCustomerId()
        {
            CustomerEnquery en = new CustomerEnquery();
            en.CustomerId = 100001;

            CustomersController _controller = new CustomersController(_customerService, _mapper);

            // Act
            var result = _controller.ListAsync(en);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }


        [Fact]
        public void Get_WhenCalled_WithInqueryEmail()
        {
            CustomerEnquery en = new CustomerEnquery();
            en.Email = "FirstName1@gmail.com";

            CustomersController _controller = new CustomersController(_customerService, _mapper);

            // Act
            var result = _controller.ListAsync(en);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }
    }
}
