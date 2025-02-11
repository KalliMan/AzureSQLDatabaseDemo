using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AzureSQLDatabaseDemo.DAL.Models;
using AzureSQLDatabaseDemo.DAL.UnitOfWork;

namespace AzureSQLDatabaseDemo.Pages_Orders
{
    public class EditModel : PageModel
    {
        private readonly IAppDbUnitOfWork _appDbUnitOfWork;

        public EditModel(IAppDbUnitOfWork appDbUnitOfWork)
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

            var order =  await _appDbUnitOfWork.OrderRepository.FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;
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

            _appDbUnitOfWork.OrderRepository.Update(Order);

            try
            {
                await _appDbUnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
            return _appDbUnitOfWork.OrderRepository.Exists(e => e.Id == id);
        }
    }
}
