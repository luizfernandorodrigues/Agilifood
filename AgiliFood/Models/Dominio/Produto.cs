using System;
using System.Collections.Generic;

namespace AgiliFood.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime TimesTamp { get; set; }
        public decimal Preco { get; set; }

        public virtual IEnumerable<ItensCardapio> ItensCardapio { get; set; }
    }
}