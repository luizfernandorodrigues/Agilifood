using System;
using System.Collections.Generic;

namespace AgiliFood.Models
{
    /// Alteração:  Removido coluna Tipo e adicionado coluna Adm
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// Alteração:  Removido coluna Tipo e adicionado coluna Adm
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// 
    /// Alteração:  Removido coluna Data de cadastro, nomeFuncionario e idFuncionario visto que não seria necesario
    /// Autor:  Luiz Fernando
    /// Data:   25/04/2019 

    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Adm { get; set; }

        public virtual IEnumerable<Pedido> Pedido { get; set; }
        public virtual IEnumerable<ContasReceber> ContasReceber { get; set; }
    }
}