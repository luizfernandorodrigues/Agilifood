using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsavel por representar os campos da view pedido
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class PedidoViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Emissão")]
        [Required(ErrorMessage = "Emissão é Obrigatória!")]
        public DateTime Emissao { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "Total é Obrigatória!")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Funcionario é Obrigatória!")]
        public Guid Id_Funcionario { get; set; }
        public string NomeFuncionario { get; set; }

        [Required(ErrorMessage = "Cardapio é Obrigatória!")]
        public Guid Id_Cardapio { get; set; }
        public virtual CardapioViewModel Cardapio { get; set; }

        public virtual IEnumerable<ItensPedidoViewModel> ItensPedido { get; set; }
    }
}