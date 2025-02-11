using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AzureSQLDatabaseDemo.DAL.Models;
using AzureSQLDatabaseDemo.DAL.UnitOfWork;

namespace AzureSQLDatabaseDemo.Pages_Customers
{
    public class CreateModel : PageModel
    {
        private readonly IAppDbUnitOfWork _appDbUnitOfWork;

        public CreateModel(IAppDbUnitOfWork appDbUnitOfWork)
        {
            _appDbUnitOfWork = appDbUnitOfWork;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _appDbUnitOfWork.CustomerRepository.AddAsync(Customer);
            await _appDbUnitOfWork.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
