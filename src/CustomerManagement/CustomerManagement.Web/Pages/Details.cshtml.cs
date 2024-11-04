using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CustomerManagement.Web.Model;
using CustomerManagement.Web.Data;

namespace CustomerManagement.Web.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomerApiService _customerApiService;

        public DetailsModel(ICustomerApiService customerApiService)
        {
            _customerApiService = customerApiService;
        }

        public CustomerViewModel CustomerViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerviewmodel = await _customerApiService.GetCustomerById(id.Value);
            if (customerviewmodel == null)
            {
                return NotFound();
            }
            else
            {
                CustomerViewModel = customerviewmodel;
            }
            return Page();
        }
    }
}
