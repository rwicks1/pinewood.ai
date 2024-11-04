using Microsoft.AspNetCore.Mvc.RazorPages;
using CustomerManagement.Web.Model;
using CustomerManagement.Web.Data;

namespace CustomerManagement.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerApiService _customerApiService;

        public IndexModel(ICustomerApiService customerApiService)
        {
            _customerApiService = customerApiService;
        }

        public IList<CustomerViewModel> CustomerViewModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CustomerViewModel = await _customerApiService.GetCustomersAsync();
        }
    }
}
