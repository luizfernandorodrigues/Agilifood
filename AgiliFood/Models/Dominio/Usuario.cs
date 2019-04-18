using System;

namespace AgiliFood.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Tipo { get; set; }
        public DateTime Cadastro { get; set; }
        public Guid Id_Funcionario { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}