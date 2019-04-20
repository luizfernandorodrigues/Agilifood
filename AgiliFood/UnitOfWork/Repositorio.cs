using AgiliFood.Interfaces;
using AgiliFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace AgiliFood.UnitOfWork
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private Contexto _contexto = null;
        DbSet<T> _dbSet;

        public Repositorio(Contexto contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<T>();
        }

        public void Adcionar(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Atualizar(T entity)
        {
            _dbSet.Attach(entity);
            ((IObjectContextAdapter)_contexto).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public int Contar()
        {
            return _dbSet.Count();
        }

        public void Deletar(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetTudo(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Where(predicate);
            }
            return _dbSet.AsEnumerable();
        }
    }

}