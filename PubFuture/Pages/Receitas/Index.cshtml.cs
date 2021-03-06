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

        public IList<Receita> Receitas { get; set; }

        [BindProperty]
        public int IdReceita { get; set; }
        public SelectList Contas { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["ContaID"] = new SelectList(_context.Contas, "ID", "TipoConta");
            double total = _context.Receitas.Sum(c => c.Valor);
            TotalReceita = total;

            await CarregarPropriedades();
            return Page();
        }


        public async Task<IActionResult> OnPostCadastrarAsync()
        {
            if (ModelState.IsValid)
            {
                if (CreditarAoSaldo().IsCompletedSuccessfully)
                {
                    ViewData["ContaID"] = new SelectList(_context.Contas, "ID", "TipoConta");
                    await _context.Receitas.AddAsync(Receita);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("../Receitas/Index");
                }
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

        public async Task CreditarAoSaldo()
        {
            Conta contaOrigem = _context.Contas.FirstOrDefault(c => c.ID == Receita.ContaID);
            if (Receita.Valor > 0)
            {
                contaOrigem.Saldo += Receita.Valor;

                _context.Attach(contaOrigem).State = EntityState.Modified;
                _context.Update(contaOrigem);
            }
        }
        private bool ReceitaExiste(int id)
        {
            return _context.Receitas.Any(e => e.ID == id);
        }
        private async Task CarregarPropriedades()
        {
            Receitas = await _context.Receitas.Include(u => u.Conta).ToListAsync();
            ViewData["ContaID"] = new SelectList(_context.Contas, "ID", "TipoConta");
        }
    }
}
