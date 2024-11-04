using CustomerManagement.Web.Model;
using System.Text.Json;

namespace CustomerManagement.Web.Data
{
    public class CustomerApiService : ICustomerApiService
    {
        public async Task CreateCustomer(CustomerViewModel customer)
        {
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.PostAsJsonAsync("http://localhost:7057/api/customer/", customer))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        public async Task DeleteCustomer(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.DeleteAsync($"http://localhost:7057/api/customer/{id}"))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        public async Task<CustomerViewModel> GetCustomerById(int id)
        {
            var customer = new CustomerViewModel();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:7057/api/customer/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var retrievedCustomer = JsonSerializer.Deserialize<CustomerViewModel>(apiResponse, options);

                    if (retrievedCustomer != null)
                    {
                        customer = retrievedCustomer;
                    }
                }
            }
            return customer;
        }

        public async Task<IList<CustomerViewModel>> GetCustomersAsync()
        {
            var customers = new List<CustomerViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("http://localhost:7057/api/customer/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var retrievedCustomers = JsonSerializer.Deserialize<List<CustomerViewModel>>(apiResponse, options);

                    if (retrievedCustomers != null)
                    {
                        customers.AddRange(retrievedCustomers);
                    }
                }
            }
            return customers;
        }

        public async Task UpdateCustomer(int id, CustomerViewModel customer)
        {
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.PutAsJsonAsync($"http://localhost:7057/api/customer/{id}", customer))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }
    }
}
