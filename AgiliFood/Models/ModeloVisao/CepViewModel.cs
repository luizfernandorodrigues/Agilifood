using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgiliFood.Models.ModeloVisao
{
    /// <summary>
    /// Classe resposavel por representar os campos da view de cep
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class CepViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Cep")]
        [Required(ErrorMessage = "O Cep é Obrigatório"), MaxLength(8, ErrorMessage = "Campo Cep deve conter no máximo 8 caracteres")]
        public string _Cep { get; set; }
        [Display(Name = "Cidade")]
        public string Id_Cidade { get; set; }
        public virtual CidadeViewModel Cidade { get; set; }
        public virtual IEnumerable<FornecedorViewModel> Fornecedor { get; set; }
    }
}