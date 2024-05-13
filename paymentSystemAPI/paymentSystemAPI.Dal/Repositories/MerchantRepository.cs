using Microsoft.EntityFrameworkCore;
using paymentSystemAPI.Application.Interfaces.IRepository;
using paymentSystemAPI.Dal.Data;
using paymentSystemAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentSystemAPI.Dal.Repositories
{
    public class MerchantRepository : IBaseRepository<Merchant> , IMercentRepository
    {
        private readonly AppDbContext _context;

        public MerchantRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Merchant merchant)
        {
            if (merchant == null)
            {
                throw new ArgumentNullException(nameof(merchant));
            }
            try
            {

                _context.Merchants.Add(merchant);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteAsync(Merchant merchant)
        {
            _context.Merchants.Remove(merchant);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Merchant>> GetAllAsync()
        {
            return await _context.Merchants.ToListAsync();
        }

        public async Task<Merchant> GetByIdAsync(string phonenumber)
        {
            return await _context.Merchants.FindAsync(phonenumber);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Merchant merchant)
        {
            _context.Entry(merchant).State = EntityState.Modified;
            await SaveChangesAsync();
        }
    }
}
