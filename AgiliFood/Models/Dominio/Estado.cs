using System;

namespace AgiliFood.Models
{
    public class Estado
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public DateTime TimesTamp { get; set; }
        public Guid Id_Pais { get; set; }
        public Pais Pais { get; set; }
    }
}