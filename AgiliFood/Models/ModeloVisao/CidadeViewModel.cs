using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsavel por representar os campos da view de cidade
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class CidadeViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome da cidade é obrigatório!"), MaxLength(100, ErrorMessage = "Nome da cidade deve conter no maximo 100 caracteres")]
        public string Nome { get; set; }
        [Display(Name = "Estado")]
        public string Id_Estado { get; set; }
        public virtual EstadoViewModel Estado { get; set; }
        public virtual IEnumerable<CepViewModel> Cep { get; set; }
    }
}