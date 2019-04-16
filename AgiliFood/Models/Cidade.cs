using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood.Models
{
    public class Cidade
    {
        public Guid Id { get; set; }
        public string  Nome { get; set; }
        public DateTime TimesTamp { get; set; }
        public Estado Estado { get; set; }


    }
}