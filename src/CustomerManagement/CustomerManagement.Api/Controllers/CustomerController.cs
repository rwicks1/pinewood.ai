using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerRepository customerRepository) : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerRepository.GetCustomers();
        }

        [HttpGet("{id}")]
        public Customer? Get(int id) => _customerRepository.GetCustomerById(id);

        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer updatedCustomer)
        {
            _customerRepository.UpdateCustomer(id, updatedCustomer);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerRepository.DeleteCustomerById(id);
        }
    }
}
