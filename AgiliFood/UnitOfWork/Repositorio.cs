using AgiliFood.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AgiliFood.UnitOfWork
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        public void Adcionar(T entity)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(T entity)
        {
            throw new NotImplementedException();
        }

        public int Contar()
        {
            throw new NotImplementedException();
        }

        public void Deletar(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetTudo(Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }
    }

}