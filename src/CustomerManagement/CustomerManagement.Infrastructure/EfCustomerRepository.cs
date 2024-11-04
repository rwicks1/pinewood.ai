using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;

namespace CustomerManagement.Infrastructure;

public class EfCustomerRepository(CustomerManagementContext context) : ICustomerRepository
{
    public void AddCustomer(Customer customer)
    {
        context.Customers.Add(customer);
        context.SaveChanges();
    }

    public bool DeleteCustomerById(int id)
    {
        var customer = context.Customers.Find(id);

        if (customer == null) return false;
        
        context.Customers.Remove(customer);
        context.SaveChanges();
        return true;
    }

    public IEnumerable<Customer> GetCustomers()
    {
        return context.Customers;
    }

    public Customer? GetCustomerById(int id)
    {
        return context.Customers.Find(id);
    }

    public Customer? UpdateCustomer(int id, Customer customer)
    {
        var customerToUpdate = context.Customers.Find(id);

        if (customerToUpdate == null) return customerToUpdate;
        
        customerToUpdate.Name = customer.Name;
        customerToUpdate.Address = customer.Address;
        customerToUpdate.PhoneNumber = customer.PhoneNumber;
        
        context.SaveChanges();

        return customerToUpdate;
    }
}