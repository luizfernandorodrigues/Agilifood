using System;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsável por representar os campos da view Itens do cardapio
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class ItensCardapioViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Valor é Obrigatória!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Produto é Obrigatória!")]
        public Guid Id_Produto { get; set; }

        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "Cardapio é Obrigatória!")]
        public Guid Id_Cardapio { get; set; }

        public string DescricaoCardapio { get; set; }
    }
}