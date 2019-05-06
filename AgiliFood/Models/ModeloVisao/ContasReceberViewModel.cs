using System;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe responsavel por representar os campos da view contas a receber
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class ContasReceberViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime Emissao { get; set; }

        [Required]
        public decimal Valor { get; set; }
        public decimal ValorPago { get; set; }

        [Display(Name ="Funcionáio")]
        public Guid Id_Usuario { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }

        [Display(Name ="Pedido")]
        public Guid Id_Pedido { get; set; }
        public virtual PedidoViewModel Pedido { get; set; }

        [Display(Name ="Fornecedor")]
        public Guid Id_Fornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}