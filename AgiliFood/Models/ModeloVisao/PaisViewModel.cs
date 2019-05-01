using System;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsavel por representar os campos da view pais
    /// </summary>
    /// <remarks>
    /// Alteração: Adicionado Display para a propriedade TimesTamp como Ultima alteração
    /// Autor:  Luiz Fernando
    /// Data:   30/04/2019
    /// </remarks>
    public class PaisViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Código")]
        [MaxLength(10, ErrorMessage = "Nome só pode conter 100 caracteres")]
        public string Codigo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é Obrigatória!")]
        [MaxLength(100, ErrorMessage = "Nome só pode conter 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "TimesTamp é Obrigatória!")]
        [Display(Name = "Ultima Alteração")]
        public DateTime TimesTamp { get; set; }

    }
}