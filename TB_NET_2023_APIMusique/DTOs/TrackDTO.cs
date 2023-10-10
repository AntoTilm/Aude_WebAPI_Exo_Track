namespace TB_NET_2023_APIMusique.DTOs
{
    //DTO simple pour le GetAll
    public class TrackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int GenreId { get; set; }
    }

    public class TrackFullDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int GenreId { get; set; }

        public IEnumerable<TrackArtistDTO> Artists { get; set; }
    }

    public class TrackArtistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public bool Featuring { get; set; }
    }

    //TODO DTO(s) ajouts/modif
}
