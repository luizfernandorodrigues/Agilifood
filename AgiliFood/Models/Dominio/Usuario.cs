using System;

namespace AgiliFood.Models
{
    /// Alteração:  Removido coluna Tipo e adicionado coluna Adm
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Cadastro { get; set; }
        public Guid Id_Funcionario { get; set; }
        public Funcionario Funcionario { get; set; }
        public bool Adm { get; set; }
    }
}