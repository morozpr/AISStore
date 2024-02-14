using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AISStore.Data;
using AISStore.Models;

namespace AISStore.Pages.EmployeeTypes
{
    public class DetailsModel : PageModel
    {
        private readonly AISStore.Data.AisdbContext _context;

        public DetailsModel(AISStore.Data.AisdbContext context)
        {
            _context = context;
        }

        public EmployeeType EmployeeType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeetype = await _context.EmployeeTypes.FirstOrDefaultAsync(m => m.EmployeeTypeId == id);
            if (employeetype == null)
            {
                return NotFound();
            }
            else
            {
                EmployeeType = employeetype;
            }
            return Page();
        }
    }
}
