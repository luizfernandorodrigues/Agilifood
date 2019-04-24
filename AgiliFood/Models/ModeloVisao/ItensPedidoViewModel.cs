using System;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsavel por representar os campos da view de itens de pedido
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class ItensPedidoViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Quantidade é Obrigatória!")]
        public int Quantidade { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "Total é Obrigatória!")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Pedido é Obrigatória!")]
        public Guid Id_Pedido { get; set; }
    }
}