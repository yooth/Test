using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Enquery
{
    public class CustomerEnquery
    {
        [Range(0, 9999999999, ErrorMessage = "Invalid Customer ID")]
        public int? CustomerId { get; set; }

        [MaxLength(25)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}
