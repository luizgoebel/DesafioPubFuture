using Microsoft.EntityFrameworkCore;
using PubFuture.Data;
using PubFuture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFuture.BLL.ReceitaBLL
{
    public class ReceitaBLL
    {
        WebContext WebContext;

        public ReceitaBLL(WebContext webContext)
        {
            WebContext = webContext;
        }

        public string Validate(Receita receita)
        {
            StringBuilder validation = new StringBuilder();

            if (string.IsNullOrWhiteSpace(receita.Valor.ToString()))
                validation.Append("<br/> Valor é obrigatório. <br/>");
            if (string.IsNullOrWhiteSpace(receita.DataRecebimento.ToString()))
                validation.Append("<br/> Data recebimento é obrigatório. <br/>");
            if (string.IsNullOrWhiteSpace(receita.DataRecebimentoEsperado.ToString()))
                validation.Append("<br/> Data recebimento esperado é obrigatório. <br/>");
            if (string.IsNullOrWhiteSpace(receita.Conta.ToString()))
                validation.Append("<br/> Conta é obrigatório. <br/>");
            if (string.IsNullOrWhiteSpace(receita.TipoReceita.ToString()))
                validation.Append("<br/> Tipo receita é obrigatório. <br/>");

            return validation.ToString();
        }

    }
}
