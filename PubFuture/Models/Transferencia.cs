using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubFuture.Models
{
    public class Transferencia : BaseModel
    {
        public Conta ContaOrigem { get; set; }
        public int ContaOrigemID { get; set; }
        public Conta ContaDestino { get; set; }
        public int ContaDestinoID { get; set; }
        public double Valor { get; set; }
    }
}
