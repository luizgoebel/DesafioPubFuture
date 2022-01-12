using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubFuture.Models
{
    public class Transferencia : BaseModel
    {
        public Conta Conta { get; set; }
        public int ContaID { get; set; }
        public double Valor { get; set; }
    }
}
