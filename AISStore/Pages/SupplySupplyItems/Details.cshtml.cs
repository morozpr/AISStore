using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AISStore.Data;
using AISStore.Models;

namespace AISStore.Pages.SupplySupplyItems
{
    public class DetailsModel : PageModel
    {
        private readonly AISStore.Data.AisdbContext _context;

        public DetailsModel(AISStore.Data.AisdbContext context)
        {
            _context = context;
        }

        public SupplySupplyItem SupplySupplyItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplysupplyitem = await _context.SupplySupplyItems.FirstOrDefaultAsync(m => m.SupplyItemsId == id);
            if (supplysupplyitem == null)
            {
                return NotFound();
            }
            else
            {
                SupplySupplyItem = supplysupplyitem;
            }
            return Page();
        }
    }
}
