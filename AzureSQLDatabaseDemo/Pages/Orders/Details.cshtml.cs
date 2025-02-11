using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AzureSQLDatabaseDemo.DAL.Context;
using AzureSQLDatabaseDemo.DAL.Models;

namespace AzureSQLDatabaseDemo.Pages_Orders
{
    public class DetailsModel : PageModel
    {
        private readonly AzureSQLDatabaseDemo.DAL.Context.AppDbContext _context;

        public DetailsModel(AzureSQLDatabaseDemo.DAL.Context.AppDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);

            if (order is not null)
            {
                Order = order;

                return Page();
            }

            return NotFound();
        }
    }
}
