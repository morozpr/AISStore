using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AISStore.Data;
using AISStore.Models;

namespace AISStore.Pages.SupplySupplyItems
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
        ViewData["SupplyId"] = new SelectList(_context.Supplies, "SupplyId", "SupplyId");
        ViewData["SupplyItemId"] = new SelectList(_context.SupplyItems, "SupplyItemId", "SupplyItemId");
            return Page();
        }

        [BindProperty]
        public SupplySupplyItem SupplySupplyItem { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SupplySupplyItems.Add(SupplySupplyItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
