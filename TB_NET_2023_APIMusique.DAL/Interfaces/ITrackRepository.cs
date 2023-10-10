using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB_NET_2023_APIMusique.DAL.Entities;
using TB_NET_2023_APIMusique.Tools.Interfaces;

namespace TB_NET_2023_APIMusique.DAL.Interfaces
{
    public interface ITrackRepository : ICrud<int, Track>
    {
        // Récupérer tous les artistes sur une track
        IEnumerable<TrackArtist> GetArtists(int trackId);

        // Ajouter/Supprimer un/des artiste(s)
        bool AddArtists(int trackId, IEnumerable<TrackArtist> artists);
        bool AddArtist(int trackId, TrackArtist artist);
        bool RemoveArtist(int trackId, TrackArtist artist);
    }
}
