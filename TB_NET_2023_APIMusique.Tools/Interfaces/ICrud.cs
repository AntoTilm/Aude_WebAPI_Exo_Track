using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_NET_2023_APIMusique.Tools.Interfaces
{
    public interface ICrud<TId, TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(TId id);
        TEntity Create(TEntity entity);
        bool Update(TId id, TEntity entity);
        bool Delete(TId id);
    }
}
