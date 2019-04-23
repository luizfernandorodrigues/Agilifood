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
        public string NomeFuncionario { get; set; }
        public string NumeroPedido { get; set; }
        public string NomeFornecedor { get; set; }
    }
}