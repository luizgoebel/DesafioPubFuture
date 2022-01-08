using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PubFuture.Data;
using PubFuture.Models;

namespace PubFuture.Pages.Despesas
{
    public class IndexModel : PageModel
    {
        private readonly WebContext _context;

        public IndexModel(WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Despesa Despesa { get; set; }

        public List<Despesa> Despesas { get; set; }

        public async Task OnGet()
        {
            Despesas = await _context.Despesas.ToListAsync();
        }
    }
}
