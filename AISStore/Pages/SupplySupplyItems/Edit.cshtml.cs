using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AISStore.Data;
using AISStore.Models;

namespace AISStore.Pages.SupplySupplyItems
{
    public class EditModel : PageModel
    {
        private readonly AISStore.Data.AisdbContext _context;

        public EditModel(AISStore.Data.AisdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SupplySupplyItem SupplySupplyItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplysupplyitem =  await _context.SupplySupplyItems.FirstOrDefaultAsync(m => m.SupplyItemsId == id);
            if (supplysupplyitem == null)
            {
                return NotFound();
            }
            SupplySupplyItem = supplysupplyitem;
           ViewData["SupplyId"] = new SelectList(_context.Supplies, "SupplyId", "SupplyId");
           ViewData["SupplyItemId"] = new SelectList(_context.SupplyItems, "SupplyItemId", "SupplyItemId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SupplySupplyItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplySupplyItemExists(SupplySupplyItem.SupplyItemsId))
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

        private bool SupplySupplyItemExists(int id)
        {
            return _context.SupplySupplyItems.Any(e => e.SupplyItemsId == id);
        }
    }
}
