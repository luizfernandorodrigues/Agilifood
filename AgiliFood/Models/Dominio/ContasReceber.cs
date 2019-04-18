using System;

namespace AgiliFood.Models
{
    public class ContasReceber
    {
        public Guid Id { get; set; }
        public DateTime Emissao { get; set; }
        public double Valor { get; set; }
        public double ValorPago { get; set; }
        public bool Quitado { get; set; }
        public Guid Id_Funcionario { get; set; }
        public Funcionario Funcionario { get; set; }
        public Guid Id_Pedido { get; set; }
        public Pedido Pedido { get; set; }
        public Guid Id_Fornecedor { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}