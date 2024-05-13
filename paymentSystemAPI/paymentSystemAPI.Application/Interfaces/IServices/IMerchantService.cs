using paymentSystemAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentSystemAPI.Application.Interfaces.IServices
{
    public interface IMerchantService
    {
        Task<MerchantDTO> GetMerchantByPhoneNumberAsync(string phonenumber);
        Task<IEnumerable<MerchantDTO>> GetAllMerchantAsync();
        Task<bool> AddMerchantAsync(MerchantDTO merchantdto);
        Task<MerchantDTO> UpdateMerchantAsync(string phonenumber, MerchantDTO merchantdto);
        Task<bool> DeleteMerchantAsync(string phonenumber);
    }
}
