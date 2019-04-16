using AgiliFood.Interfaces;
using AgiliFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private Contexto _contexto = null;
        public UnitOfWork()
        {
            _contexto = new Contexto();
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }
        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}