using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CustomerManagement.Web.Model;
using CustomerManagement.Web.Data;

namespace CustomerManagement.Web.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerApiService _customerApiService;

        public CreateModel(ICustomerApiService customerApiService)
        {
            _customerApiService = customerApiService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CustomerViewModel CustomerViewModel { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _customerApiService.CreateCustomer(CustomerViewModel);

            return RedirectToPage("./Index");
        }
    }
}
