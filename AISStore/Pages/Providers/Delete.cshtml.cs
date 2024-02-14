using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AISStore.Data;
using AISStore.Models;

namespace AISStore.Pages.Providers
{
    public class DeleteModel : PageModel
    {
        private readonly AISStore.Data.AisdbContext _context;

        public DeleteModel(AISStore.Data.AisdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Provider Provider { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers.FirstOrDefaultAsync(m => m.ProviderId == id);

            if (provider == null)
            {
                return NotFound();
            }
            else
            {
                Provider = provider;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers.FindAsync(id);
            if (provider != null)
            {
                Provider = provider;
                _context.Providers.Remove(Provider);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
