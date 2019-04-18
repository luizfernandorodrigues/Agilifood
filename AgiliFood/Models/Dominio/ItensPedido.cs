using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood.Models
{
    public class ItensPedido
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public double Total { get; set; }
        public Guid Id_Pedido { get; set; }
        public Pedido Pedido { get; set; }
    }
}