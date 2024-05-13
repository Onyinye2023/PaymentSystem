using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentSystemAPI.Application.DTOs
{
    public class MerchantDTO
    {
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Business Id is required")]
        public string BusinessId { get; set; }

        [Required(ErrorMessage = "Business name is required")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Date of Establishment is required")]
        public DateTime DateOfEstablishment { get; set; }
        public double AverageTransactionVolume { get; set; }

    }
}
