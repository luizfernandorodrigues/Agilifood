using System;

namespace AgiliFood.Models
{
    /// <summary>
    /// Classe responsavel por representar os campos da view de pedido
    /// </summary>
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