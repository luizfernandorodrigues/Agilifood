using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood.Models
{
    public class Cardapio
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime Cadastro { get; set; }
        public DateTime TimesTamp { get; set; }
        public Guid Id_Fornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

    }
}