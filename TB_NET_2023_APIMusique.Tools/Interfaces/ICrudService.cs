using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TB_NET_2023_APIMusique.Tools.Interfaces
{
    public interface ICrudService<TId, TModel> where TModel : class
    {
        IEnumerable<TModel> GetAll();
        TModel? GetById(TId id);
        TModel Create(TModel entity);
        bool Update(TId id, TModel entity);
        bool Delete(TId id);
    }
}
