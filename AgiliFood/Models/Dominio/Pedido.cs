using System;

namespace AgiliFood.Models
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public DateTime Emissao { get; set; }
        public decimal Total { get; set; }
        public Guid Id_Funcionario { get; set; }
        public Funcionario Funcionario { get; set; }
        public Guid Id_Cardapio { get; set; }
        public Cardapio Cardapio { get; set; }
    }
}