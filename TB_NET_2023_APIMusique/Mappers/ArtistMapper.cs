using TB_NET_2023_APIMusique.BLL.Models;
using TB_NET_2023_APIMusique.DTOs;

namespace TB_NET_2023_APIMusique.Mappers
{
    public static class ArtistMapper
    {
        // Model BLL into DTO API
        public static ArtistDTO ToDTO(this Artist model)
        {
            return new ArtistDTO
            {
                Id = model.Id,
                Name = model.Name,
                BirthDate = model.BirthDate,
                DeathDate = model.DeathDate,
            };
        }

        //DTO API into Model BLL
        public static Artist ToModel(this ArtistDataDTO artist)
        {
            return new Artist
            {
                Id = 0,
                Name = artist.Name,
                BirthDate = artist.BirthDate,
                DeathDate = artist.DeathDate,
            };
        }
    }
}
