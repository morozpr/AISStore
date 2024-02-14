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

namespace AISStore.Pages.Clients
{
    [Authorize(Roles = "Employee,Admin")]

    public class IndexModel(AISStore.Data.AisdbContext context) : PageModel
    {
        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Client = await context.Clients.ToListAsync();
        }
    }
}
