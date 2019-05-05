using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood.Models
{
    public class Cep
    {
        public Guid Id { get; set; }
        public string _Cep { get; set; }
        public DateTime TimesTamp { get; set; }

        public Guid Id_Cidade { get; set; }
        public virtual Cidade Cidade { get; set; }

        public virtual IEnumerable<Fornecedor> Fornecedor { get; set; }
    }
}