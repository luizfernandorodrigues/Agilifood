using System;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsavel por representar os campo da view funcionario
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class FuncionarioViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é Obrigatória!")]
        [MaxLength(100, ErrorMessage = "Nome só pode conter 100 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Endereço é Obrigatória!")]
        [MaxLength(100, ErrorMessage = "Endereço só pode conter 100 caracteres")]
        public string Endereco { get; set; }

        [Display(Name = "Numero Endereço")]
        [MaxLength(20, ErrorMessage = "Numero Endereço só pode conter 20 caracteres")]
        public string NumeroEndereco { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Bairro é Obrigatória!")]
        [MaxLength(80, ErrorMessage = "Bairro só pode conter 80 caracteres")]
        public string Bairro { get; set; }

        [Display(Name = "Fone")]
        [Required(ErrorMessage = "Telefone é Obrigatória!")]
        [MaxLength(11, ErrorMessage = "Telefone só pode conter 11 caracteres")]
        public string Fone { get; set; }

        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "Cpf é Obrigatória!")]
        [MaxLength(11, ErrorMessage = "Cpf só pode conter 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Cep é Obrigatória!")]
        public Guid Id_Cep { get; set; }
        public string Cep { get; set; }
    }
}