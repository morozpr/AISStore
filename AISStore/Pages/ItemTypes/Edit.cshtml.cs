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

namespace AISStore.Pages.ItemTypes
{
    public class EditModel : PageModel
    {
        private readonly AISStore.Data.AisdbContext _context;

        public EditModel(AISStore.Data.AisdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ItemType ItemType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemtype =  await _context.ItemTypes.FirstOrDefaultAsync(m => m.ItemTypeId == id);
            if (itemtype == null)
            {
                return NotFound();
            }
            ItemType = itemtype;
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

            _context.Attach(ItemType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTypeExists(ItemType.ItemTypeId))
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

        private bool ItemTypeExists(int id)
        {
            return _context.ItemTypes.Any(e => e.ItemTypeId == id);
        }
    }
}
