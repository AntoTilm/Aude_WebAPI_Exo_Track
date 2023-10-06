using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_NET_2023_APIMusique.BLL.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
    }
}
