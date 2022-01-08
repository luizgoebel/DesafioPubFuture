using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubFuture.Models
{
    public class Conta : BaseModel
    {
        public double Saldo { get; set; }
        public string TipoConta { get; set; }
        public string InstituicaoFinanceira { get; set; }
    }
}
