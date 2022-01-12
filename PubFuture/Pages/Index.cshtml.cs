using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PubFuture.Data;
using PubFuture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubFuture.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebContext _context;

        public IndexModel(WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Receita Receita { get; set; }

        [BindProperty]
        public Conta Contas { get; set; }

        [BindProperty]
        public Despesa Despesa { get; set; }

        public double TotalReceita { get; set; }
        public double TotalDespesa { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {

            double totalRecei = _context.Receitas.Sum(c => c.Valor);
            TotalReceita = totalRecei;

            double totalDesp = _context.Despesas.Sum(c => c.Valor);
            TotalDespesa = totalDesp;

            return Page();
        }
    }
}
