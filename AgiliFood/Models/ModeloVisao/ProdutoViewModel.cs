using System;
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

        [Display(Name = "Tipo Produto")]
        [Required(ErrorMessage = "Tipo é Obrigatória!")]
        public int Tipo { get; set; }

        [Display(Name = "Imagem")]
        public byte[] Imagem { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Preço é Obrigatória!")]
        public decimal Preco { get; set; }
    }
}