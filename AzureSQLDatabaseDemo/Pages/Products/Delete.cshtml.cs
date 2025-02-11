using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AzureSQLDatabaseDemo.DAL.Models;
using AzureSQLDatabaseDemo.DAL.UnitOfWork;

namespace AzureSQLDatabaseDemo.Pages_Products
{
    public class DeleteModel : PageModel
    {
        private readonly IAppDbUnitOfWork _appDbUnitOfWork;

        public DeleteModel(IAppDbUnitOfWork appDbUnitOfWork)
        {
            _appDbUnitOfWork = appDbUnitOfWork;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _appDbUnitOfWork.ProductRepository.FirstOrDefaultAsync(m => m.Id == id);

            if (product is not null)
            {
                Product = product;

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

            var product = await _appDbUnitOfWork.ProductRepository.FindAsync(id.Value);
            if (product != null)
            {
                Product = product;
                _appDbUnitOfWork.ProductRepository.Remove(Product);
                await _appDbUnitOfWork.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
