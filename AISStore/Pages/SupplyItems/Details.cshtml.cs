using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AISStore.Data;
using AISStore.Models;

namespace AISStore.Pages.SupplyItems
{
    public class DetailsModel : PageModel
    {
        private readonly AISStore.Data.AisdbContext _context;

        public DetailsModel(AISStore.Data.AisdbContext context)
        {
            _context = context;
        }

        public SupplyItem SupplyItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyitem = await _context.SupplyItems.FirstOrDefaultAsync(m => m.SupplyItemId == id);
            if (supplyitem == null)
            {
                return NotFound();
            }
            else
            {
                SupplyItem = supplyitem;
            }
            return Page();
        }
    }
}
