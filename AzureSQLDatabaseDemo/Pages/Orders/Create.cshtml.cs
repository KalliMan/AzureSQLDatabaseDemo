using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AzureSQLDatabaseDemo.DAL.Context;
using AzureSQLDatabaseDemo.DAL.Models;

namespace AzureSQLDatabaseDemo.Pages_Orders
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
        public Order Order { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
