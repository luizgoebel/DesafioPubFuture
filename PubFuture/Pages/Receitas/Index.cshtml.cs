using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public double TotalReceita { get; set; }

        public List<Receita> Receitas { get; set; }

        [BindProperty]
        public int IdReceita { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            double total = _context.Receitas.Sum(c => c.Valor);
            TotalReceita = total;
            await CarregarPropriedades();
            return Page();
        }

        
        public async Task<IActionResult> OnPostCadastrarAsync()
        {
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

        public async Task<IActionResult> OnPostEditarAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Attach(Receita).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToPage("../Receitas/Index");
            }

            if (!ReceitaExiste(Receita.ID))
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeletarAsync()
        {

            Receita receita = await _context.Receitas.FirstOrDefaultAsync(c => c.ID == IdReceita);
            if (receita != null)
            {
                _context.Remove(receita);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Receitas/Index");
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
