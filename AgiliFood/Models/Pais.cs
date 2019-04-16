using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AgiliFood.Models
{
    [Table("Pais")]
    public class Pais
    {
        [Required(ErrorMessage ="id é obrigatório")]
        [Column("id")]
        public Guid Id { get; set; }

        [StringLength(10)]
        [Column("codigo")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Nome é Obrigatório!")]
        [StringLength(100)]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [Column("timestamp")]
        public DateTime TimesTamp { get; set; }

        public ICollection<Estado> Estados { get; set; }

    }
}