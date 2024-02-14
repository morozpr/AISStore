using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AISStore.Data;
using AISStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace AISStore.Pages.SupplyItems
{
    [Authorize(Roles = "Stockman,Admin")]
    public class IndexModel : PageModel
    {
        private readonly AISStore.Data.AisdbContext _context;

        public IndexModel(AISStore.Data.AisdbContext context)
        {
            _context = context;
        }

        public IList<SupplyItem> SupplyItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SupplyItem = await _context.SupplyItems.ToListAsync();
        }
    }
}
