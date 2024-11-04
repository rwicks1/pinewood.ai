using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManagement.Web.Model;
using CustomerManagement.Web.Data;

namespace CustomerManagement.Web.Pages
{
    public class EditModel : PageModel
    {
        private readonly ICustomerApiService _customerApiService;

        public EditModel(ICustomerApiService customerApiService)
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
            CustomerViewModel = customerviewmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(CustomerViewModel.Id.HasValue)
                await _customerApiService.UpdateCustomer(CustomerViewModel.Id.Value, CustomerViewModel);

            return RedirectToPage("./Index");
        }
    }
}
