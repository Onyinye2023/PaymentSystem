using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentSystemAPI.Application.DTOs
{
    public class CustomerDTO
    {
        [Required(ErrorMessage = "National Id number is required")]
        public string NationalIdNumber { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
        public string TransactionHistory { get; set; }

    }
}
