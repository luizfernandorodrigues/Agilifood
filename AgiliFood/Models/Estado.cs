using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgiliFood.Models
{
    [Table("Estado")]
    public class Estado
    {
        [Column("id")]
        [Required(ErrorMessage = "id é obrigatório!")]
        public Guid Id { get; set; }

        [Column("nome")]
        [Required(ErrorMessage = "Nome é Obrigatório!")]
        public string Nome { get; set; }

        [Column("sigla")]
        [Required(ErrorMessage = "Sigla é Obrigátorio")]
        [MaxLength(2, ErrorMessage = "Sigla só pode conter 2 caratcteres!")]
        public string Sigla { get; set; }

        [Column("timestamp")]
        public DateTime TimesTamp { get; set; }

        [ForeignKey("pais_id")]
        public Pais Pais { get; set; }
    }
}