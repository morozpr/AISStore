using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AISStore.Data;
using AISStore.Models;

namespace AISStore.Pages.ItemTypes
{
    public class DeleteModel : PageModel
    {
        private readonly AISStore.Data.AisdbContext _context;

        public DeleteModel(AISStore.Data.AisdbContext context)
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

            var itemtype = await _context.ItemTypes.FirstOrDefaultAsync(m => m.ItemTypeId == id);

            if (itemtype == null)
            {
                return NotFound();
            }
            else
            {
                ItemType = itemtype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemtype = await _context.ItemTypes.FindAsync(id);
            if (itemtype != null)
            {
                ItemType = itemtype;
                _context.ItemTypes.Remove(ItemType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
