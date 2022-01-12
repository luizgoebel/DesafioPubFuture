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

namespace PubFuture.Pages.Contas
{
    public class IndexModel : PageModel
    {
        private readonly WebContext _context;

        public IndexModel(WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Conta Conta { get; set; }

        [BindProperty]
        public Transferencia Transferencia { get; set; }
        public double TotalContas { get; set; }

        public List<Conta> Contas { get; set; }
        [BindProperty]
        public int IdConta { get; set; }
        public SelectList ListaContas { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["ContaID"] = new SelectList(_context.Contas, "ID", "TipoConta");

            double total = _context.Contas.Sum(c => c.Saldo);
            TotalContas = total;

            await CarregarPropriedades();
            return Page();
        }
        public async Task<IActionResult> OnPostCadastrarAsync()
        {
            if (ModelState.IsValid)
            {
                await _context.Contas.AddAsync(Conta);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Contas/Index");
            }

            if (!ContaExiste(Conta.ID))
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostEditarAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Attach(Conta).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToPage("../Contas/Index");
            }

            if (!ContaExiste(Conta.ID))
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeletarAsync()
        {

            Conta conta = await _context.Contas.FirstOrDefaultAsync(c => c.ID == IdConta);
            if (conta != null)
            {
                _context.Remove(conta);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Contas/Index");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostTransferirAsync()
        {

            Conta conta = await _context.Contas.FirstOrDefaultAsync(c => c.ID == IdConta);
            if (conta != null)
            {
                _context.Remove(conta);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Contas/Index");
            }

            return Page();
        }



        private bool ContaExiste(int id)
        {
            return _context.Contas.Any(e => e.ID == id);
        }
        private async Task CarregarPropriedades()
        {
            Contas = await _context.Contas.ToListAsync();
        }
    }
}
