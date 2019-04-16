using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood.Models
{
    public class ContasReceber
    {
        public Guid Id { get; set; }
        public DateTime Emissao { get; set; }
        public double Valor { get; set; }
        public double ValorPago { get; set; }
        public bool Quitado { get; set; }
        public Funcionario Funcionario { get; set; }
        public Pedido Pedido { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}