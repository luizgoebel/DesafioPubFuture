using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PubFuture.Models
{
    public class Conta : BaseModel
    {
        [Required(ErrorMessage = "Saldo obrigatório.")]
        public double Saldo { get; set; }
        [Required(ErrorMessage = "Tipo conta obrigatório.")]
        public string TipoConta { get; set; }
        [Required(ErrorMessage = "Instituição financeira obrigatório.")]
        public string InstituicaoFinanceira { get; set; }
    }
}
