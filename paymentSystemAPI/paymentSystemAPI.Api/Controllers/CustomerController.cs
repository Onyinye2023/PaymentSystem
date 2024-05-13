using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using paymentSystemAPI.Application.DTOs;
using paymentSystemAPI.Application.Interfaces.IServices;

namespace paymentSystemAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpPost("addCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customerdto)
        {
            try
            {
                if(customerdto == null)
                {
                    return BadRequest("Invalid customer data");
                }

                await _customerService.AddCustomerAsync(customerdto);
                return Ok("Customer added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding customer { ex.Message}");
                return StatusCode(500, "Internal server error");   
            }
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllCustomerAsync();
                if (customers != null)
                {
                    return Ok(customers);
                }
                return NotFound("Failed to fetch customers");
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting customer {ex.Message}");
                return StatusCode(500, "Inter server error");
            }
        }

        [HttpGet("get-by-id/{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(customerId);
                if (customer == null)
                {
                    return NotFound($"Customer with the ID {customerId} not found");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting customer {ex.Message}");
                return StatusCode(500, "Inter server error");
            }
        }

        [HttpPut("update-customer/{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] CustomerDTO customerdto)
        {
            try
            {
               var updatedCustomer = await _customerService.UpdateCustomerAsync(customerId, customerdto);
                return Ok(updatedCustomer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting customer {ex.Message}");
                return StatusCode(500, "Inter server error");
            }
        }

        [HttpDelete("delete-customer/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            try
            {
               var customer = await _customerService.DeleteCustomerAsync(customerId);
                if (customer == false)
                {
                    return NotFound($"No customer found with the ID: {customerId}");
                }
                return Ok("Customer deleted succesfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting customer {ex.Message}");
                return StatusCode(500, "Inter server error");
            }
        }
    }
}
