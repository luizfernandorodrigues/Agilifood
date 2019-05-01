using System;
using System.Collections.Generic;

namespace AgiliFood.Models
{
    public class Estado
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public DateTime TimesTamp { get; set; }
        public Guid Id_Pais { get; set; }
        public virtual Pais Pais { get; set; }

        public virtual IEnumerable<Cidade> Cidades { get; set; }
    }
}