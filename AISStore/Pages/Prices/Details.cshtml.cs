using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AISStore.Data;
using AISStore.Models;

namespace AISStore.Pages.Prices
{
    public class DetailsModel : PageModel
    {
        private readonly AISStore.Data.AisdbContext _context;

        public DetailsModel(AISStore.Data.AisdbContext context)
        {
            _context = context;
        }

        public Price Price { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var price = await _context.Prices.FirstOrDefaultAsync(m => m.PriceId == id);
            if (price == null)
            {
                return NotFound();
            }
            else
            {
                Price = price;
            }
            return Page();
        }
    }
}
