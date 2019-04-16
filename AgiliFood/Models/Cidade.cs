using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgiliFood.Models
{
    public class Cidade
    {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é Obrigatório")]
        public string Nome { get; set; }

        [Required]
        public DateTime TimesTamp { get; set; }

        [ForeignKey("estado_id")]
        public Estado Estado { get; set; }

    }
}