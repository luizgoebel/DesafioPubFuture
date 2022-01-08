using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PubFuture.Models
{
    public class Despesa : BaseModel
    {
        [Required(ErrorMessage = "Valor obrigatório.")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Data obrigatório.")]
        [Display(Name = "Data pagamento esperado")]
        public DateTime DataPagamentoEsperado { get; set; }

        [Display(Name = "Data do pagamento")]
        public DateTime DataPagamento { get; set; }

        [Required(ErrorMessage = "Tipo despesa obrigátório.")]
        public string TipoDespesa { get; set; }


        public int IdConta { get; set; }
        public Conta Conta { get; set; }
    }
}
