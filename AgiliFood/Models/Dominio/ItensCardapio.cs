using System;

namespace AgiliFood.Models
{
    public class ItensCardapio
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public Guid Id_Produto { get; set; }
        public virtual Produto Produto { get; set; }
        public Guid Id_Cardapio { get; set; }
        public virtual Cardapio Cardapio { get; set; }
    }
}