using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsável por representar os campos da view de login
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   25/04/2019
    /// </remarks>
    public class LoginViewModel
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe a login do usuário")]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}