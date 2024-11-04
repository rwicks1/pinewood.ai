using Castle.Core.Resource;
using CustomerManagement.Api.Controllers;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Services;
using Moq;
using Xunit;

namespace CustomerManagement.Api.Tests
{
    public class CustomerControllerTests
    {
        private CustomerController _customerController;
        public CustomerControllerTests() 
        {
            var customers = new List<Customer>
            {
                new Customer{ Id = 1, Name = "Leanne Fairclough", Address = "6 Weatherly Station", PhoneNumber = "01743 845569"},
                new Customer{ Id = 2, Name = "Russ Wicks", Address = "12 Autumn Park", PhoneNumber = "01684 547236"},
                new Customer{ Id = 3, Name = "Joe Bloggs", Address = "55 Milford Way", PhoneNumber = "01235 452124"},
                new Customer{ Id = 4, Name = "Jane Doe", Address = "89 Mitchley Drive", PhoneNumber = "01256 584753"}
            };


            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.AddCustomer(It.IsAny<Customer>())).Callback((Customer c) => customers.Add(c));
            customerServiceMock.Setup(x => x.GetCustomers()).Returns(customers);
            customerServiceMock.Setup(x => x.GetCustomerById(It.IsAny<int>())).Returns((int id) => customers.SingleOrDefault(x => x.Id == id));
            customerServiceMock.Setup(x => x.DeleteCustomerById(It.IsAny<int>())).Returns((int id) =>
            {
                var customer = customers.FirstOrDefault(x => x.Id == id);
                return customer != null && customers.Remove(customer);
            });
            customerServiceMock.Setup(x => x.UpdateCustomer(It.IsAny<int>(),It.IsAny<Customer>())).Returns(
                (int id, Customer c) =>
                {
                    var customer = customers.FirstOrDefault(x => x.Id == id);

                    if (customer != null)
                    {
                        customer.PhoneNumber = c.PhoneNumber;
                        customer.Address = c.Address;
                        customer.Name = c.Name;
                    }

                    return customer;
                });

            _customerController = new CustomerController(customerServiceMock.Object);        
        }

        [Fact]
        public void WhenGetIsCalledCorrectNumberOfCustomersIsReturned()
        {
            int expected = 4;
    
            var customers = _customerController.Get();

            Assert.Equal(expected, customers.Count());
        }

        [Fact]
        public void WhenGetByIdIsCalledCorrectCustomerIsReturned()
        {
            string expectedName = "Leanne Fairclough";

            var customer = _customerController.Get(1);

            Assert.NotNull(customer);
            Assert.Equal(expectedName, customer.Name);
        }

        [Fact]
        public void WhenPostIsCalledCorrectNumberOfCustomersIsReturned()
        {
            int expected = 5;

            _customerController.Post(new Customer { Id = 5, Name = "Test Customer", Address = "Test Address", PhoneNumber = "123456789" });

            var customers = _customerController.Get();

            Assert.Equal(expected, customers.Count());
        }

        [Fact]
        public void WhenPostIsCalledCorrectCustomerIsAdded()
        {
            string expected = "Test Customer";

            _customerController.Post(new Customer { Id = 5, Name = "Test Customer", Address = "Test Address", PhoneNumber = "123456789" });

            var customer = _customerController.Get(5);

            Assert.NotNull(customer);
            Assert.Equal(expected, customer.Name);
        }

        [Fact]
        public void WhenPostIsCalledCustomerIsUpdated()
        {
            string expected = "01743 845568";

            _customerController.Put(1, new Customer { Id = 1, Name = "Leanne Fairclough", Address = "6 Weatherly Station", PhoneNumber = "01743 845568" });

            var customer = _customerController.Get(1);

            Assert.NotNull(customer);
            Assert.Equal(expected, customer.PhoneNumber);
        }
    }
}
