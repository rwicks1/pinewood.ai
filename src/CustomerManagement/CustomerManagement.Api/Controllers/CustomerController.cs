using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerService.GetCustomers();
        }

        [HttpGet("{id}")]
        public Customer? Get(int id) => _customerService.GetCustomerById(id);

        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            _customerService.AddCustomer(customer);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer updatedCustomer)
        {
            _customerService.UpdateCustomer(id, updatedCustomer);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerService.DeleteCustomerById(id);
        }
    }
}
