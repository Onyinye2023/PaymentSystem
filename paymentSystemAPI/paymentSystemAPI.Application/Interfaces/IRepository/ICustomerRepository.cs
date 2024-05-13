using Microsoft.EntityFrameworkCore.ChangeTracking;
using paymentSystemAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentSystemAPI.Application.Interfaces.IRepository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
    }
}
