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


            GraficoDespesa();
            GraficoReceita();
            GraficoContas();

            return Page();
        }

        public void GraficoReceita()
        {
            //Despesas
            var listaReceita = (from r in _context.Receitas
                                group r by new { r.TipoReceita }
                     into g
                                select new GraficoReceitaViewModel
                                {
                                    TipoReceita = g.Key.TipoReceita,
                                    TotalReceita = g.Sum(x => x.Valor)
                                }).ToList();


            string valor = string.Empty;
            string label = string.Empty;

            for (int i = 0; i < listaReceita.Count; i++)
            {
                valor += listaReceita[i].TotalReceita + ",";
                label += "'" + listaReceita[i].TipoReceita.ToString() + "',";
            }

            ViewData["valoress"] = valor;
            ViewData["labelss"] = label;
        }

        public void GraficoDespesa()
        {
            //Despesas
            var lista = (from r in _context.Despesas
                         group r by new { r.TipoDespesa }
                     into g
                         select new GraficoDespesaViewModel
                         {
                             TipoDespesa = g.Key.TipoDespesa,
                             TotalDespesa = g.Sum(x => x.Valor)
                         }).ToList();


            string valores = string.Empty;
            string labels = string.Empty;

            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].TotalDespesa + ",";
                labels += "'" + lista[i].TipoDespesa.ToString() + "',";
            }

            ViewData["valores"] = valores;
            ViewData["labels"] = labels;
        }

        public void GraficoContas()
        {
            //Contas
            var lista = (from r in _context.Contas
                         group r by new { r.TipoConta }
                     into g
                         select new GraficoContaViewModel
                         {
                             TipoConta = g.Key.TipoConta,
                             TotalSaldo = g.Sum(x => x.Saldo)
                         }).ToList();


            string valoresContas = string.Empty;
            string labelsTipo = string.Empty;

            for (int i = 0; i < lista.Count; i++)
            {
                valoresContas += lista[i].TotalSaldo + ",";
                labelsTipo += "'" + lista[i].TipoConta.ToString() + "',";
            }

            ViewData["val"] = valoresContas;
            ViewData["lab"] = labelsTipo;
        }
    }
}
