using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManagement.Web.Model;
using CustomerManagement.Web.Data;

namespace CustomerManagement.Web.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerApiService _customerApiService;

        public DeleteModel(ICustomerApiService customerApiService)
        {
            _customerApiService = customerApiService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _customerApiService.DeleteCustomer(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
