using AutoMapper;
using Microsoft.Extensions.Logging;
using paymentSystemAPI.Application.DTOs;
using paymentSystemAPI.Application.Interfaces.IRepository;
using paymentSystemAPI.Application.Interfaces.IServices;
using paymentSystemAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace paymentSystemAPI.Application.Services
{
    public class MerchantService : IMerchantService
    {
        private readonly IBaseRepository<Merchant> _merchantRepo;
        private readonly IMercentRepository _merchantRepo2;
        private readonly IMapper _mapper;
        private readonly ILogger<Merchant> _logger;

        public MerchantService(IBaseRepository<Merchant> merchantRepo, IMercentRepository merchantRepo2, IMapper mapper, ILogger<Merchant> logger)
        {
            _merchantRepo = merchantRepo;
            _logger = logger;
            _mapper = mapper;
            _merchantRepo2 = merchantRepo2;
        }
        public async Task<bool> AddMerchantAsync(MerchantDTO merchantdto)
        {
            try
            {
                var merchant = _mapper.Map<Merchant>(merchantdto);
                if (merchant == null)
                {
                    return false;
                }

                await _merchantRepo.AddAsync(merchant);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteMerchantAsync(string phonenumber)
        {
            var merchant = await _merchantRepo2.GetByIdAsync(phonenumber);
            if (merchant == null)
            {
                _logger.LogWarning($"Merchant with phone number {phonenumber} not found");
                return false;
            }

           await _merchantRepo.DeleteAsync(merchant);
            return true;
        }

        public async Task<IEnumerable<MerchantDTO>> GetAllMerchantAsync()
        {
            var merchants = await _merchantRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<MerchantDTO>>(merchants);
        }

        public async Task<MerchantDTO> GetMerchantByPhoneNumberAsync(string phonenumber)
        {
            var merchant = await _merchantRepo2.GetByIdAsync(phonenumber);
            if (merchant == null)
            {
                _logger.LogWarning($"Merchant with the phone number {phonenumber} not found");
                return null;
            }

            return _mapper.Map<MerchantDTO>(merchant);
        }

        public async Task<MerchantDTO> UpdateMerchantAsync(string phonenumber, MerchantDTO merchantdto)
        {
            var existingMerchant = await _merchantRepo2.GetByIdAsync(phonenumber);
            if (existingMerchant == null)
            {
                _logger.LogWarning($"Merchant with the phone number {phonenumber} not found");
                return null;
            }
           
            _mapper.Map(merchantdto, existingMerchant);
            await _merchantRepo.UpdateAsync(existingMerchant);
            return (merchantdto);
        }
    }
}
