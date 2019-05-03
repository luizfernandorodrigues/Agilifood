using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsavel por representar os campos da view de produto
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código é Obrigatória!")]
        [MaxLength(20, ErrorMessage = "Código só pode conter 20 caracteres")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição é Obrigatória!")]
        [MaxLength(100, ErrorMessage = "Nome só pode conter 100 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Preço é Obrigatória!")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
        public virtual IEnumerable<ItensCardapioViewModel> ItensCardapio { get; set; }
    }
}