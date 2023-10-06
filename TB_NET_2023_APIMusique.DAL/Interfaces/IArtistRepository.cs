using TB_NET_2023_APIMusique.DAL.Entities;
using TB_NET_2023_APIMusique.Tools.Interfaces;

namespace TB_NET_2023_APIMusique.DAL.Interfaces
{
    public interface IArtistRepository : ICrud<int, Artist>
    {
        public bool IsSingingOnTrack(int id);
    }
}
