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

        [Required(ErrorMessage = "Data pagemnto esperado obrigatório.")]
        [Display(Name = "Data pagamento esperado")]
        [DataType(DataType.Date)]
        public DateTime DataPagamentoEsperado { get; set; }

        [Required(ErrorMessage = "Data pagamento obrigatório.")]
        [Display(Name = "Data do pagamento")]
        [DataType(DataType.Date)]
        public DateTime DataPagamento { get; set; }

        [Display(Name = "Tipo despesa")]
        [Required(ErrorMessage = "Tipo despesa obrigátório.")]
        public string TipoDespesa { get; set; }


        public int ContaID { get; set; }
        public virtual Conta Conta { get; set; }
    }
}
