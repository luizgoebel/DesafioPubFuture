using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PubFuture.BLL.ReceitaBLL;
using PubFuture.Data;
using PubFuture.Models;

namespace PubFuture.Pages.Receitas
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

        public List<Receita> Receitas { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await CarregarPropriedades();
            return Page();
        }

        public async Task<IActionResult> OnPostCadastrarAsync()
        {
            Receita.Create = DateTime.Now;
            Receita.Change = DateTime.Now;
            if (ModelState.IsValid)
            {
                await _context.Receitas.AddAsync(Receita);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Receitas/Index");
            }

            if (!ReceitaExiste(Receita.ID))
            {
                return NotFound();
            }
            return Page();
        }

        private bool ReceitaExiste(int id)
        {
            return _context.Receitas.Any(e => e.ID == id);
        }
        private async Task CarregarPropriedades()
        {
            Receitas = await _context.Receitas.ToListAsync();
        }
    }
}
