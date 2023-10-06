using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB_NET_2023_APIMusique.BLL.CustomExceptions;
using TB_NET_2023_APIMusique.BLL.Interfaces;
using TB_NET_2023_APIMusique.BLL.Mappers;
using TB_NET_2023_APIMusique.BLL.Models;
using TB_NET_2023_APIMusique.DAL.Interfaces;

namespace TB_NET_2023_APIMusique.BLL.Services
{
    public class ArtistService : IArtistService
    {
        // Injection du repo
        private readonly IArtistRepository _ArtistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _ArtistRepository = artistRepository;
        }

        public IEnumerable<Artist> GetAll()
        {
            return _ArtistRepository.GetAll().Select(a => a.ToModel());
        }

        public Artist? GetById(int id)
        {
            return _ArtistRepository.GetById(id)?.ToModel();
        }

        public Artist Insert(Artist artist)
        {
            return _ArtistRepository.Create(artist.ToEntity()).ToModel();
        }
        public bool Delete(int id)
        {
            // Verif si pas dans la MM
            if (_ArtistRepository.IsSingingOnTrack(id))
            {
                throw new AlreadySingingException("Artist is already singing on a track");
            }

            // Tenter supp
            bool deleted = _ArtistRepository.Delete(id);
            if (!deleted)
            {
                throw new NotFoundException("Artist not found");
            }

            return deleted;
        }


        public bool Update(int id, Artist artist)
        {
            bool updated = _ArtistRepository.Update(id, artist.ToEntity());
            if(!updated)
            {
                throw new NotFoundException("Artist not found");
            }
            return updated;
        }
    }
}
