using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood.Models
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string NumeroEndereco { get; set; }
        public string Bairro { get; set; }
        public string Fone { get; set; }
        public string Cpf { get; set; }
        public Cep Cep { get; set; }
    }
}