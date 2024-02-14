using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AISStore.Data;
using AISStore.Models;

namespace AISStore.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly AISStore.Data.AisdbContext _context;

        public CreateModel(AISStore.Data.AisdbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
        ViewData["OrderItemsId"] = new SelectList(_context.OrderItems, "OrderItemsId", "OrderItemsId");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
