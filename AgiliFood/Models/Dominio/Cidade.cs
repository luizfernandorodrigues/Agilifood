using System;

namespace AgiliFood.Models
{
    public class Cidade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime TimesTamp { get; set; }
        public Guid Id_Estado { get; set; }
        public Estado Estado { get; set; }

    }
}