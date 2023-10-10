using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB_NET_2023_APIMusique.DAL.Entities;
using TB_NET_2023_APIMusique.DAL.Interfaces;
using TB_NET_2023_APIMusique.Tools.Utils;

namespace TB_NET_2023_APIMusique.DAL.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly DbConnection _DbConnection;
        public TrackRepository(DbConnection dbConnection)
        {
            _DbConnection = dbConnection;
        }

        // Mapper(s)
        public Track Mapper(IDataRecord record)
        {
            return new Track
            {
                Id = (int)record["Id_TRACK"],
                Name = (string)record["NAME"],
                Duration = (int)record["DURATION"],
                GenreId = (int)record["GENRE_ID"]
            };
        }

        public TrackArtist MapperTA(IDataRecord record)
        {
            return new TrackArtist
            {
                ArtistId = (int)record["ARTIST_ID"],
                Featuring = (bool)record["FEATURING"]
            };
        }


        public IEnumerable<Track> GetAll()
        {
            using(DbCommand cmd = _DbConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM [TRACK]";
                _DbConnection.Open();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return Mapper(reader);
                    }
                }
                _DbConnection.Close();
            };
        }
        public Track? GetById(int id)
        {
            Track? track = null;
            using(DbCommand cmd = _DbConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM [TRACK] WHERE [Id_TRACK] = @Id";
                cmd.addParamWithValue("Id", id);

                _DbConnection.Open();
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        track = Mapper(reader);
                    }
                }
                _DbConnection.Close();
            };
            return track;
        }

        public IEnumerable<TrackArtist> GetArtists(int trackId)
        {
            using(DbCommand cmd = _DbConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM [Track_Artist] WHERE [TRACK_ID] = @Id";
                cmd.addParamWithValue("Id", trackId);

                _DbConnection.Open();
                // ExecuteReader() -> Le résultat de la requête est une table avec une plusieures colonnes et potentiellement plusieurs lignes
                // ExecuteScalar() -> Le résultat de la requête est une seule valeur (ex Count, avg)
                // ExecuteNonQuery() -> Le résultat de la requête renvoie juste le nombre de lignes ajoutées/modifiées/supprimées
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return MapperTA(reader);
                    }
                };
                _DbConnection.Close();
            };
        }



        public Track Create(Track entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }


        public bool Update(int id, Track entity)
        {
            throw new NotImplementedException();
        }
        public bool AddArtists(int trackId, IEnumerable<TrackArtist> artists)
        {
            throw new NotImplementedException();
        }


        public bool AddArtist(int trackId, TrackArtist artist)
        {
            throw new NotImplementedException();
        }
                
        public bool RemoveArtist(int trackId, TrackArtist artist)
        {
            throw new NotImplementedException();
        }

       
    }
}
