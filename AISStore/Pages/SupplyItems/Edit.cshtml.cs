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

namespace AISStore.Pages.SupplyItems
{
    public class EditModel : PageModel
    {
        private readonly AISStore.Data.AisdbContext _context;

        public EditModel(AISStore.Data.AisdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SupplyItem SupplyItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyitem =  await _context.SupplyItems.FirstOrDefaultAsync(m => m.SupplyItemId == id);
            if (supplyitem == null)
            {
                return NotFound();
            }
            SupplyItem = supplyitem;
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

            _context.Attach(SupplyItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplyItemExists(SupplyItem.SupplyItemId))
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

        private bool SupplyItemExists(int id)
        {
            return _context.SupplyItems.Any(e => e.SupplyItemId == id);
        }
    }
}
