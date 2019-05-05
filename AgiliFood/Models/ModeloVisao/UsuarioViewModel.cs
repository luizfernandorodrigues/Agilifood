using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsavel por representar os campos da view de usuario
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// 
    /// Alteração: removido o campo de nome de funcionario e id funcionario e data de cadastro
    ///     setado o tipo de dados para o campo de senha
    /// Autor:  Luiz Fernando
    /// Data:   25/04/2019
    /// </remarks>

    public class UsuarioViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é Obrigatória!")]
        [MaxLength(100, ErrorMessage = "Nome só pode conter 100 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login é Obrigatória!")]
        [MaxLength(100, ErrorMessage = "Login só pode conter 100 caracteres")]
        public string Login { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Email é Obrigatória!")]
        [MaxLength(100, ErrorMessage = "Email só pode conter 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha é Obrigatória!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Administrador")]
        [Required(ErrorMessage = "Tipo é Obrigatória!")]
        public bool Adm { get; set; }

        public virtual IEnumerable<PedidoViewModel> PedidoViewModel { get; set; }
        public virtual IEnumerable<ContasReceberViewModel> ContasReceberViewModel { get; set; }

    }
}