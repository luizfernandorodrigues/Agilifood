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

        [Required(ErrorMessage = "Quantidade é Obrigatório")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Produto é Obrigatória!")]
        [Display(Name = "Produto")]
        public Guid Id_Produto { get; set; }

        public virtual ProdutoViewModel Produto { get; set; }

        [Required(ErrorMessage = "Cardapio é Obrigatória!")]
        public Guid Id_Cardapio { get; set; }
        public virtual CardapioViewModel Cardapio { get; set; }
    }
}