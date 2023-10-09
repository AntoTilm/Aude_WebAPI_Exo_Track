using System.ComponentModel.DataAnnotations;

namespace TB_NET_2023_APIMusique.DTOs
{
    public class ArtistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
    }

    public class ArtistDataDTO
    {
        //DataAnnotations -> Sert à valider les données entrées
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeathDate { get; set; }

    }
}
