using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AzureSQLDatabaseDemo.DAL.Models;
using AzureSQLDatabaseDemo.DAL.UnitOfWork;

namespace AzureSQLDatabaseDemo.Pages_Orders
{
    public class DeleteModel : PageModel
    {
        private readonly IAppDbUnitOfWork _appDbUnitOfWork;

        public DeleteModel(IAppDbUnitOfWork appDbUnitOfWork)
        {
            _appDbUnitOfWork = appDbUnitOfWork;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _appDbUnitOfWork.OrderRepository.FirstOrDefaultAsync(m => m.Id == id);

            if (order is not null)
            {
                Order = order;

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

            var order = await _appDbUnitOfWork.OrderRepository.FindAsync(id.Value);
            if (order != null)
            {
                Order = order;
                _appDbUnitOfWork.OrderRepository.Remove(Order);
                await _appDbUnitOfWork.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
