﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_NET_2023_APIMusique.BLL.Models
{
    public class TrackArtist
    {
        //public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
        public bool Featuring { get; set; }
    }
}
