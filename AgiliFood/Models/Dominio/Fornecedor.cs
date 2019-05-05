using System;
using System.Collections.Generic;

namespace AgiliFood.Models
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string Logradouro { get; set; }
        public string NumeroEndereco { get; set; }
        public string Bairro { get; set; }
        public string Fone { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public DateTime Cadastro { get; set; }
        public DateTime TimesTamp { get; set; }

        public Guid Id_Cep { get; set; }
        public virtual Cep Cep { get; set; }

        public virtual IEnumerable<Cardapio> Cardapio { get; set; }
    }
}