using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PubFuture.Models
{
    public class Receita : BaseModel
    {
        [Required(ErrorMessage = "Valor obrigatório.")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Data obrigatório.")]
        [Display(Name = "Data recebimento esperado")]
        public DateTime DataRecebimentoEsperado { get; set; }

        [Display(Name = "Data recebimento")]
        public DateTime DataRecebimento { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Tipo de receita obrigatório.")]
        [Display(Name = "Tipo de receita")]
        public string TipoReceita { get; set; }


        public int IdConta { get; set; }
        public Conta Conta { get; set; }
    }
}
