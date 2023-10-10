using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = TB_NET_2023_APIMusique.BLL.Models;
using Entities = TB_NET_2023_APIMusique.DAL.Entities;

namespace TB_NET_2023_APIMusique.BLL.Mappers
{
    public static class TrackArtistMapper
    {
        public static Models.TrackArtist ToModel(this Entities.TrackArtist entity)
        {
            return new Models.TrackArtist
            {
                //Artist -> Pas encore, c'est notre service qui va aller le remplir
                Featuring = entity.Featuring,
            };
        }

        public static Entities.TrackArtist ToEntity(this Models.TrackArtist model)
        {
            return new Entities.TrackArtist
            {
                //Comme on a mis Artist en nullable sur notre model, on vérifie s'il est null
                //C'est sensé ne pas arriver si on fait correctement notre service mais on a du le mettre en nul pour pouvoir le remplir après passage du mapper
                ArtistId = model.Artist is null ? 0 : model.Artist.Id,
                Featuring = model.Featuring

            };
        }
    }
}
