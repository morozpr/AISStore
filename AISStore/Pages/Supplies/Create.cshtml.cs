using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AISStore.Data;
using AISStore.Models;

namespace AISStore.Pages.Supplies
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
        ViewData["ProviderId"] = new SelectList(_context.Providers, "ProviderId", "ProviderId");
            return Page();
        }

        [BindProperty]
        public Supply Supply { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Supplies.Add(Supply);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}