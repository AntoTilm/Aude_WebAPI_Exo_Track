using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = TB_NET_2023_APIMusique.BLL.Models;
using Entities = TB_NET_2023_APIMusique.DAL.Entities;

namespace TB_NET_2023_APIMusique.BLL.Mappers
{
    public static class TrackMapper
    {
        public static Models.Track ToModel(this Entities.Track entity)
        {
            return new Models.Track
            {
                Id = entity.Id,
                Name = entity.Name,
                Duration = entity.Duration,
                GenreId = entity.GenreId,
                //Artists  -> Sera rempli dans le service
            };
        }

        public static Entities.Track ToEntity(this Models.Track model) 
        {
            return new Entities.Track
            {
                Id = model.Id,
                Name = model.Name,
                Duration = model.Duration,
                GenreId = model.GenreId
            };
        }
    }
}
