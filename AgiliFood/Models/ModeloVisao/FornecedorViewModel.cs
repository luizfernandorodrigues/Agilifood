using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsavel por representar os campos da view fornecedor
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class FornecedorViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Razão Social é Obrigatória!")]
        [MaxLength(200, ErrorMessage = "Razão Social só pode conter 200 caracteres")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Fantasia")]
        [MaxLength(100, ErrorMessage = "Fantasia só pode conter 100 caracteres")]
        public string Fantasia { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "Endereço é Obrigatório!")]
        [MaxLength(100, ErrorMessage = "Endereço só pode conter 100 caracteres")]
        public string Logradouro { get; set; }

        [Display(Name = "Numero do Endereço")]
        [MaxLength(10, ErrorMessage = "Numero do Endereço só pode conter 10 caracteres")]
        public string NumeroEndereco { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Bairro é Obrigatório!")]
        [MaxLength(100, ErrorMessage = "Bairro só pode conter 100 caracteres")]
        public string Bairro { get; set; }

        [Display(Name = "Telefone")]
        [MaxLength(11, ErrorMessage = "Telefone só pode conter 11 caracteres")]
        public string Fone { get; set; }

        [Display(Name = "Cnpj")]
        [Required(ErrorMessage = "Cnpj é Obrigatório!")]
        [MaxLength(14, ErrorMessage = "Cnpj só pode conter 14 caracteres")]
        public string Cnpj { get; set; }

        [Display(Name = "E-mail")]
        [MaxLength(80, ErrorMessage = "E-mail só pode conter 80 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "Data de Cadastro é Obrigatório!")]
        public DateTime Cadastro { get; set; }

        [Required(ErrorMessage = "Cep é Obrigatório!")]
        public Guid Id_Cep { get; set; }
        public virtual CepViewModel Cep { get; set; }
        public virtual IEnumerable<CardapioViewModel> Cardapio { get; set; }


    }
}