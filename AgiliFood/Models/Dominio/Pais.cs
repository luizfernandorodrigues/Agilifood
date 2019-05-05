using System;
using System.Collections.Generic;

namespace AgiliFood.Models
{
    public class Pais
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime TimesTamp { get; set; }

        public virtual IEnumerable<Estado> Estados { get; set; }

    }
}