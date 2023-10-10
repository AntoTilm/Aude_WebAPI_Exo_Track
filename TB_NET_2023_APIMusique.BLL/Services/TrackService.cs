using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB_NET_2023_APIMusique.BLL.Interfaces;
using TB_NET_2023_APIMusique.BLL.Mappers;
using TB_NET_2023_APIMusique.BLL.Models;
using TB_NET_2023_APIMusique.DAL.Interfaces;

namespace TB_NET_2023_APIMusique.BLL.Services
{
    public class TrackService : ITrackService
    {
        
        private readonly ITrackRepository _TrackRepository;
        private readonly IArtistRepository _ArtistRepository;
        public TrackService(ITrackRepository trackRepository, IArtistRepository artistRepository)
        {
            _TrackRepository = trackRepository;
            _ArtistRepository = artistRepository;

        }

        public IEnumerable<Track> GetAll()
        {
            //Si on veut récupérer la liste de toutes les tracks sans les artistes, on renvoie juste notre GetAll de repo en mappant
            return _TrackRepository.GetAll().Select(t => t.ToModel());
            //Si on veut récupérer la liste de toutes les tracks avec les artistes, on devra faire notre jointure

        }

        public Track? GetById(int id)
        {
            Track? track = _TrackRepository.GetById(id)?.ToModel();

            //Si track pas null, on ajoute la liste des artistes, sinon osef
            // (truc) => truc+"pouet"
            // function(truc) { return truc+"pouet"}
            //(ta, a) => new { pouet = "bidule"})
            //(ta, a) => { return new { pouet = "bidule"} }

            if(track is not null)
            {
                IEnumerable<TrackArtist> trackArtists = _TrackRepository.GetArtists(id)
                    .Join(_ArtistRepository.GetAll(), ta => ta.ArtistId, a => a.Id, (ta, a) =>  
                    {
                        //Transformation du TrackArtist Entity reçu de la jointure en TrackArtistModel
                        TrackArtist taModel = ta.ToModel();
                        //On rempli ensuite la prop Artist de notre TrackArtist Model avec l'artiste reçu de la jointure
                        taModel.Artist = a.ToModel();
                        return taModel;
                    });

                track.Artists = trackArtists;
            }

            return track;
        }

        public bool AddArtist(int trackId, TrackArtist artist)
        {
            throw new NotImplementedException();
        }

        public bool AddArtists(int trackId, IEnumerable<TrackArtist> artists)
        {
            throw new NotImplementedException();
        }
        public bool RemoveArtist(int trackId, int artistId)
        {
            throw new NotImplementedException();
        }
        public Track Create(Track entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Track entity)
        {
            throw new NotImplementedException();
        }
    }
}
