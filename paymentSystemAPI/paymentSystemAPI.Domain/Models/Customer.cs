using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentSystemAPI.Domain.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string NationalIdNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber  { get; set; }
        public string TransactionHistory { get; set; }

    }
}
