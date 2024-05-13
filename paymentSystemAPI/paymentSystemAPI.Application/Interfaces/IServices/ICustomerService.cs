using paymentSystemAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentSystemAPI.Application.Interfaces.IServices
{
    public interface ICustomerService
    {
        Task<CustomerDTO> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<CustomerDTO>> GetAllCustomerAsync();
        Task<bool> AddCustomerAsync(CustomerDTO customerdto);
        Task<CustomerDTO> UpdateCustomerAsync(int customerId, CustomerDTO customerdto);
        Task<bool> DeleteCustomerAsync(int customerId);
    }
}
