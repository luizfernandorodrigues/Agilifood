﻿using System;

namespace AgiliFood.Models
{
    public class ItensPedido
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        public Guid Id_Pedido { get; set; }
        public Pedido Pedido { get; set; }
    }
}