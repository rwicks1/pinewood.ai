using CustomerManagement.Web.Model;

namespace CustomerManagement.Web.Data
{
    public interface ICustomerApiService
    {
        Task<IList<CustomerViewModel>> GetCustomersAsync();
        Task<CustomerViewModel> GetCustomerById(int id);
        Task CreateCustomer(CustomerViewModel customer);
        Task UpdateCustomer(int id, CustomerViewModel customer);
        Task DeleteCustomer(int id);
    }
}
