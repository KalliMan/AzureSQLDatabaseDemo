using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AzureSQLDatabaseDemo.DAL.Models;
using AzureSQLDatabaseDemo.DAL.UnitOfWork;

namespace AzureSQLDatabaseDemo.Pages_Customers
{
    public class DeleteModel : PageModel
    {
        private readonly IAppDbUnitOfWork _appDbUnitOfWork;

        public DeleteModel(IAppDbUnitOfWork appDbUnitOfWork)
        {
            _appDbUnitOfWork = appDbUnitOfWork;
        }
  
        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _appDbUnitOfWork.CustomerRepository.FirstOrDefaultAsync(m => m.Id == id);

            if (customer is not null)
            {
                Customer = customer;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _appDbUnitOfWork.CustomerRepository.FirstOrDefaultAsync(m => m.Id == id);
            if (customer != null)
            {
                Customer = customer;
                _appDbUnitOfWork.CustomerRepository.Remove(Customer);
                await _appDbUnitOfWork.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
