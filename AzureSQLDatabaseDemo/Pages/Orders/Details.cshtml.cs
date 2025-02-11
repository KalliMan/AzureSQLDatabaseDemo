using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AzureSQLDatabaseDemo.DAL.Models;
using AzureSQLDatabaseDemo.DAL.UnitOfWork;

namespace AzureSQLDatabaseDemo.Pages_Orders
{
    public class DetailsModel : PageModel
    {
        private readonly IAppDbUnitOfWork _appDbUnitOfWork;

        public DetailsModel(IAppDbUnitOfWork appDbUnitOfWork)
        {
            _appDbUnitOfWork = appDbUnitOfWork;
        }

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
    }
}
