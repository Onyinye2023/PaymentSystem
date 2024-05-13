using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentSystemAPI.Domain.Models
{
    public class Merchant
    {
        [Key]
        public string PhoneNumber { get; set; }

        public string BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfEstablishment { get; set; }
        public double AverageTransactionVolume { get; set; }
    }
}
