using Microsoft.EntityFrameworkCore;
using paymentSystemAPI.Application.Interfaces.IRepository;
using paymentSystemAPI.Dal.Data;
using paymentSystemAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentSystemAPI.Application.Repositories
{
    public class CustomerRepository : IBaseRepository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Customer customer)
        {
           if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            try
            {
                _context.Customers.Add(customer);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await SaveChangesAsync();
        }
    }
}
