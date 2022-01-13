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

namespace PubFuture.Pages.Despesas
{
    public class IndexModel : PageModel
    {
        private readonly WebContext _context;

        public IndexModel(WebContext context)
        {
            _context = context;
        }
        public double TotalDespesa { get; set; }

        [BindProperty]
        public Despesa Despesa { get; set; }

        [BindProperty]
        public int IdConta { get; set; }
        [BindProperty]
        public int IdDespesa { get; set; }

        [BindProperty]
        public List<Despesa> Despesas { get; set; }
        public async Task<IActionResult> OnGet()
        {
            ViewData["ContaID"] = new SelectList(_context.Contas, "ID", "TipoConta");

            double total = _context.Despesas.Sum(c => c.Valor);
            TotalDespesa = total;

            await CarregarPropriedades();
            return Page();
        }

        public async Task<IActionResult> OnPostCadastrarAsync()
        {
            if (ModelState.IsValid)
            {
                if (DebitarDoSaldo().IsCompletedSuccessfully)
                {
                    ViewData["ContaID"] = new SelectList(_context.Despesas, "ID", "TipoDespesa");
                    await _context.Despesas.AddAsync(Despesa);
                    //DebitarDoSaldo();
                    await _context.SaveChangesAsync();
                    return RedirectToPage("../Despesas/Index");
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostEditarAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Attach(Despesa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToPage("../Despesas/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeletarAsync()
        {

            Despesa despesa = await _context.Despesas.FirstOrDefaultAsync(c => c.ID == IdDespesa);
            if (despesa != null)
            {
                _context.Remove(despesa);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Despesas/Index");
            }

            return Page();
        }

        public async Task DebitarDoSaldo()
        {
            Conta contaOrigem = _context.Contas.FirstOrDefault(c => c.ID == Despesa.ContaID);
            if (Despesa.Valor > contaOrigem.Saldo || contaOrigem.Saldo <= 0)
            {
                RedirectToPage("errorSaldo");
            }
            if (Despesa.Valor <= contaOrigem.Saldo)
            {
                contaOrigem.Saldo -= Despesa.Valor;

                _context.Attach(contaOrigem).State = EntityState.Modified;
                _context.Update(contaOrigem);
            }
        }

        private async Task CarregarPropriedades()
        {
            Despesas = await _context.Despesas.ToListAsync();
        }
    }
}
