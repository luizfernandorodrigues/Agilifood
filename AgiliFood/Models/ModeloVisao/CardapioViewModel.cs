using System;
using System.ComponentModel.DataAnnotations;
namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsavel por representar os campos da view de cardapio
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class CardapioViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código é Obrigatório!"), MaxLength(10, ErrorMessage = "Campo Código deve conter no Máximo 10 Caracteres")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição é Obrigatório!"), MaxLength(30, ErrorMessage = "Campo Descrição deve conter no Máximo 30 Caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "A data de cadastro é obrigatória")]
        public DateTime Cadastro { get; set; }
        public string NomeFornecedor { get; set; }
    }
}