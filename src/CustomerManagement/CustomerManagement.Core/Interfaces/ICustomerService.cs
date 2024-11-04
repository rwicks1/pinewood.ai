using CustomerManagement.Core.Entities;

namespace CustomerManagement.Core.Interfaces
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        bool DeleteCustomerById(int id);
        IEnumerable<Customer> GetCustomers();
        Customer? GetCustomerById(int id);        
        Customer? UpdateCustomer(int id, Customer customer);        
    }
}
