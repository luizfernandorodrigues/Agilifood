using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood.Models
{
    public class ItensCardapio
    {
        public Guid Id { get; set; }
        public double Valor { get; set; }
        public DateTime TimesTamp { get; set; }
        public Produto Produto { get; set; }
        public Cardapio Cardapio { get; set; }
    }
}