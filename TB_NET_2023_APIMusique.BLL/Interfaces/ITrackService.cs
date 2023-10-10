using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB_NET_2023_APIMusique.BLL.Models;
using TB_NET_2023_APIMusique.Tools.Interfaces;

namespace TB_NET_2023_APIMusique.BLL.Interfaces
{
    public interface ITrackService : ICrudService<int, Track>
    {
        //Crud apporté par ICrudService

        public bool AddArtists(int trackId, IEnumerable<TrackArtist> artists);
        public bool AddArtist(int trackId, TrackArtist artist);
        public bool RemoveArtist(int trackId, int artistId);
    }
}
