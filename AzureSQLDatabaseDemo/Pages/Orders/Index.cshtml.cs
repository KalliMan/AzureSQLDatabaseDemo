using Microsoft.AspNetCore.Mvc.RazorPages;
using AzureSQLDatabaseDemo.DAL.Models;
using AzureSQLDatabaseDemo.DAL.UnitOfWork;

namespace AzureSQLDatabaseDemo.Pages_Orders
{
    public class IndexModel : PageModel
    {
        private readonly IAppDbUnitOfWork _appDbUnitOfWork;

        public IndexModel(IAppDbUnitOfWork appDbUnitOfWork)
        {
            _appDbUnitOfWork = appDbUnitOfWork;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _appDbUnitOfWork.OrderRepository.ToListAsync();
        }
    }
}
