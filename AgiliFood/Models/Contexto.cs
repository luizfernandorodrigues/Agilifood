using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgiliFood.Models
{
    public partial class Contexto : DbContext
    {
        public Contexto()
                    : base("EFConnectionString") { }

        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }
}