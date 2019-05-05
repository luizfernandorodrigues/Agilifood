using System;

namespace AgiliFood.Models
{
    public class ContasReceber
    {
        public Guid Id { get; set; }
        public DateTime Emissao { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorPago { get; set; }
        public bool Quitado { get; set; }

        public Guid Id_Usuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Guid Id_Pedido { get; set; }
        public virtual Pedido Pedido { get; set; }

        public Guid Id_Fornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}