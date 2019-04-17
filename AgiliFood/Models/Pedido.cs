using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood.Models
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public DateTime Emissao { get; set; }
        public double Total { get; set; }
        public Funcionario Funcionario { get; set; }
        public Cardapio Cardapio { get; set; }
    }
}