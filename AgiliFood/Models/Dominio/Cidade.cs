using System;
using System.Collections.Generic;

namespace AgiliFood.Models
{
    public class Cidade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime TimesTamp { get; set; }
        public Guid Id_Estado { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual IEnumerable<Cep> Cep { get; set; }
    }
}