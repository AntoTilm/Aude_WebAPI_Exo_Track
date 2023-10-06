using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = TB_NET_2023_APIMusique.BLL.Models;
using Entities = TB_NET_2023_APIMusique.DAL.Entities;

namespace TB_NET_2023_APIMusique.BLL.Mappers
{
    public static class ArtistMapper
    {
        public static Models.Artist ToModel(this Entities.Artist entity)
        {
            return new Models.Artist
            {
                Id = entity.Id,
                Name = entity.Name,
                BirthDate = entity.Birthdate,
                DeathDate = entity.Deathdate,
            };
        }

        public static Entities.Artist ToEntity(this Models.Artist model)
        {
            return new Entities.Artist
            {
                Id = model.Id,
                Name = model.Name,
                Deathdate = model.DeathDate,
                Birthdate = model.BirthDate
            };
        }
    }
}
