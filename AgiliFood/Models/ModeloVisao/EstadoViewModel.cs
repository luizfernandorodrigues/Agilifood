using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsavel por representar os campos da view de cadastro de estado
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class EstadoViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Nome do Estado")]
        [Required(ErrorMessage = "Nome do Estado é Obrigatório"), MaxLength(50, ErrorMessage = "Nome do Estado deve conter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Sigla da UF")]
        [Required(ErrorMessage = "Sigla é Obrigatório!"), MaxLength(2, ErrorMessage = "Sigla deve conter no maximo 2 caracteres!")]
        public string Sigla { get; set; }

        [Display(Name = "País")]
        public Guid Id_Pais { get; set; }

        public string NomePais { get; set; }
        public Pais Pais { get; set; }
    }
}