using System;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsavel por representar os campos da view pais
    /// </summary>
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
        public DateTime TimesTamp { get; set; }

    }
}