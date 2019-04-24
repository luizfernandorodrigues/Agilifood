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
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha é Obrigatória!")]
        public string Senha { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Tipo é Obrigatória!")]
        public bool Adm { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "Data de Cadastro é Obrigatória!")]
        public DateTime Cadastro { get; set; }

        [Required(ErrorMessage = "Funcionario é Obrigatória!")]
        public Guid Id_Funcionario { get; set; }

        public string NomeFuncionario { get; set; }
    }
}