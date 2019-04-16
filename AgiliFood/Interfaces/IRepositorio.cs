using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AgiliFood.Interfaces
{
   public interface IRepositorio<T> where T: class
    {
        IEnumerable<T> GetTudo(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        void Adcionar(T entity);
        void Atualizar(T entity);
        void Deletar(T entity);
        int Contar();
    }
}
