﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_NET_2023_APIMusique.DAL.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public DateTime? Deathdate { get; set; }
    }
}
