using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.DTOs.Customer;

namespace AlymSoftGo.API.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCustomers([FromQuery] string? search = null)
        {
            var response = await _customerService.GetCustomersAsync(search);
            return HandleResponse(response);
        }

        [HttpGet("{customerId:int}")]
        [Authorize]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var response = await _customerService.GetCustomerByIdAsync(customerId);
            return HandleResponse(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveCustomer([FromBody] SaveCustomerRequestDto request)
        {
            var response = await _customerService.SaveCustomerAsync(request);
            return HandleResponse(response);
        }

        [HttpDelete("{customerId:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var response = await _customerService.DeleteCustomerAsync(customerId);
            return HandleResponse(response);
        }
    }
}
