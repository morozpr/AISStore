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

namespace AISStore.Pages.Prices
{
    [Authorize(Roles = "Employee,Admin")]
    public class IndexModel : PageModel
    {
        private readonly AISStore.Data.AisdbContext _context;

        public IndexModel(AISStore.Data.AisdbContext context)
        {
            _context = context;
        }

        public IList<Price> Price { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Price = await _context.Prices.ToListAsync();
        }
    }
}
