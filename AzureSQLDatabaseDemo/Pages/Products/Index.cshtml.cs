using Microsoft.AspNetCore.Mvc.RazorPages;
using AzureSQLDatabaseDemo.DAL.Models;
using AzureSQLDatabaseDemo.DAL.UnitOfWork;

namespace AzureSQLDatabaseDemo.Pages_Products
{
    public class IndexModel : PageModel
    {
        private readonly IAppDbUnitOfWork _appDbUnitOfWork;

        public IndexModel(IAppDbUnitOfWork appDbUnitOfWork)
        {
            _appDbUnitOfWork = appDbUnitOfWork;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _appDbUnitOfWork.ProductRepository.ToListAsync();
        }
    }
}
