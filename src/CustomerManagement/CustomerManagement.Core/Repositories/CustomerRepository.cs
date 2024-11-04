using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;

namespace CustomerManagement.Core.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers = new List<Customer>
        {
            new Customer{ Id = 1, Name = "Leanne Fairclough", Address = "6 Weatherly Station", PhoneNumber = "01743 845569"},
            new Customer{ Id = 2, Name = "Russ Wicks", Address = "12 Autumn Park", PhoneNumber = "01684 547236"},
            new Customer{ Id = 3, Name = "Joe Bloggs", Address = "55 Milford Way", PhoneNumber = "01235 452124"},
            new Customer{ Id = 4, Name = "Jane Doe", Address = "89 Mitchley Drive", PhoneNumber = "01256 584753"}
        };

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public bool DeleteCustomerById(int id)
        {
            var customer = _customers.FirstOrDefault(x => x.Id == id);
            return customer != null && _customers.Remove(customer);
        }

        public Customer? GetCustomerById(int id) => _customers.SingleOrDefault(x => x.Id == id);

        public IEnumerable<Customer> GetCustomers()
        {
            return _customers;
        }

        public Customer? UpdateCustomer(int id, Customer customer)
        {
            var customerToUpdate = _customers.SingleOrDefault(x => x.Id == id);

            if (customerToUpdate != null)
            {
                customerToUpdate.PhoneNumber = customer.PhoneNumber;
                customerToUpdate.Address = customer.Address;
                customerToUpdate.Name = customer.Name;

            }

            return customerToUpdate;
        }
    }
}
