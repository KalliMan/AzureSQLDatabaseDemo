using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AzureSQLDatabaseDemo.DAL.Models;

namespace AzureSQLDatabaseDemo.Pages_Customers
{
    public class CreateModel : PageModel
    {
        private readonly AzureSQLDatabaseDemo.DAL.Context.AppDbContext _context;

        public CreateModel(AzureSQLDatabaseDemo.DAL.Context.AppDbContext context)
        {
            _context = context;
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

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
