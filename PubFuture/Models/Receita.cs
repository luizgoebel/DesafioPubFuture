using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PubFuture.Models
{
    public class Receita : BaseModel
    {
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime DataRecebimentoEsperado { get; set; }
        public DateTime DataRecebimento { get; set; }
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Conta obrigátório.")]
        [MaxLength(6, ErrorMessage = "Máximo de 6 dígitos"), MinLength(6, ErrorMessage = "Mínimo de 6 dígitos")]
        public string Conta { get; set; }
        [Required]
        public string TipoReceita { get; set; }
    }
}
