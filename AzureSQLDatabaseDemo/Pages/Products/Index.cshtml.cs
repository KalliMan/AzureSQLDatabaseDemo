using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AzureSQLDatabaseDemo.DAL.Context;
using AzureSQLDatabaseDemo.DAL.Models;

namespace AzureSQLDatabaseDemo.Pages_Products
{
    public class IndexModel : PageModel
    {
        private readonly AzureSQLDatabaseDemo.DAL.Context.AppDbContext _context;

        public IndexModel(AzureSQLDatabaseDemo.DAL.Context.AppDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
