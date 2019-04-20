using System;

namespace AgiliFood.Models
{
    public class ItensCardapio
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime TimesTamp { get; set; }
        public Guid Id_Produto { get; set; }
        public Produto Produto { get; set; }
        public Guid Id_Cardapio { get; set; }
        public Cardapio Cardapio { get; set; }
    }
}