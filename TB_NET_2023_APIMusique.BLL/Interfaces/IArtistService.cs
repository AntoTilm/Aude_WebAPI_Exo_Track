using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB_NET_2023_APIMusique.BLL.Models;

namespace TB_NET_2023_APIMusique.BLL.Interfaces
{
    public interface IArtistService
    {
        public IEnumerable<Artist> GetAll();
        public Artist? GetById(int id);
        public Artist Insert(Artist artist);
        public bool Update(int id, Artist artist);
        public bool Delete(int id);
    }
}
