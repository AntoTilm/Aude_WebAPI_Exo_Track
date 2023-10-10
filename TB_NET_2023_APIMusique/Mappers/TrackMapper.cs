using TB_NET_2023_APIMusique.BLL.Models;
using TB_NET_2023_APIMusique.DTOs;

namespace TB_NET_2023_APIMusique.Mappers
{
    public static class TrackMapper
    {
        public static TrackDTO ToDTO(this Track trackModel)
        {
            return new TrackDTO
            {
                Id = trackModel.Id,
                Name = trackModel.Name,
                Duration = trackModel.Duration,
                GenreId = trackModel.GenreId

            };
        }

        public static TrackFullDTO ToFullDTO(this Track trackModel)
        {
            return new TrackFullDTO
            {
                Id = trackModel.Id,
                Name = trackModel.Name,
                Duration = trackModel.Duration,
                GenreId = trackModel.GenreId,
                Artists = trackModel.Artists.Select(a => a.ToTrackArtistDTO())
            };
        }

        public static TrackArtistDTO ToTrackArtistDTO(this TrackArtist trackArtistModel)
        {
            return new TrackArtistDTO
            {
                Featuring = trackArtistModel.Featuring,
                Id = trackArtistModel.Artist.Id,
                Name = trackArtistModel.Artist.Name,
            };
        }


    }
}
