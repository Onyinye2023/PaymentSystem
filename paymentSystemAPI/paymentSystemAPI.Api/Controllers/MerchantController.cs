using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using paymentSystemAPI.Application.DTOs;
using paymentSystemAPI.Application.Interfaces.IServices;
using paymentSystemAPI.Application.Services;
using paymentSystemAPI.Domain.Models;
using System.Runtime.InteropServices;

namespace paymentSystemAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantService _merchantService;
        private readonly ILogger<MerchantController> _logger;

        public MerchantController(IMerchantService merchantService, ILogger<MerchantController> logger)
        {
            _logger = logger;
            _merchantService = merchantService;
        }

        [HttpPost("add-merchant")]
        public async Task<IActionResult> AddMerchant([FromBody] MerchantDTO merchantdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid credentials");
            }
            try
            {
                if (merchantdto == null)
                {
                    return BadRequest("Invalid credentials");
                }
               
                await _merchantService.AddMerchantAsync(merchantdto);
                return Ok("Merchant added succesfully");
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error adding merchant {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("get-all-merchants")]
        public async Task<IActionResult> GetAllMerchant()
        {
            try
            {
                var merchants = await _merchantService.GetAllMerchantAsync();

                if (merchants == null)
                {
                    return NotFound("No Merchant found");
                }

                return Ok(merchants);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error fetching merchant {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get-by-phonenumber/{phonenumber}")]
        public async Task<IActionResult> GetAllMerchantByPhoneNumber(string phonenumber)
        {
            try
            {
                var merchant = await _merchantService.GetMerchantByPhoneNumberAsync(phonenumber);
                if (merchant == null)
                {
                    return BadRequest($"No merchant found with the phone number: {phonenumber}");
                }

                return Ok(merchant);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching merchant {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update-merchant/{phonenumber}")]
        public async Task<IActionResult> UpdateMerchant(string phonenumber, [FromBody] MerchantDTO merchantdto)
        {
            try
            {
               var updatedMerchant = await _merchantService.UpdateMerchantAsync(phonenumber, merchantdto);
                return Ok(updatedMerchant);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error fetching merchant {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("delete-merchant{phonenumber}")]
        public async Task<IActionResult> DeleteMerchant(string phonenumber)
        {
            try
            {
                var merchant = await _merchantService.DeleteMerchantAsync(phonenumber);

                if (merchant == false)
                {
                    return NotFound($"No Merchant found with the phone number: {phonenumber}");
                }
                return Ok("Merchant deleted succesfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting customer {ex.Message}");
                return StatusCode(500, "Inter server error");
            }
        }
    }
}
