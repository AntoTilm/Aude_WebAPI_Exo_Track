using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using TB_NET_2023_APIMusique.DAL.Entities;
using TB_NET_2023_APIMusique.DAL.Interfaces;
using TB_NET_2023_APIMusique.Tools.Utils;
using Microsoft.Identity.Client;

namespace TB_NET_2023_APIMusique.DAL.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly DbConnection _DbConnection;

        public ArtistRepository(DbConnection dbConnection)
        {
            _DbConnection = dbConnection;
        }

        public Artist Mapper(IDataRecord record)
        {
            return new Artist
            {
                Id = (int)record["Id_ARTIST"],
                Name = (string)record["NAME"],
                Birthdate = (DateTime)record["BIRTH_DATE"],
                Deathdate = record["DEATH_DATE"] is DBNull ? null : (DateTime)record["DEATH_DATE"]
            };
        }

        public IEnumerable<Artist> GetAll()
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Artist]";
                _DbConnection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return Mapper(reader);
                    }
                };
                _DbConnection.Close();
            };
        }

        public Artist? GetById(int id)
        {
            Artist? result = null;
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Artist] WHERE [Id_ARTIST] = @id";
                command.addParamWithValue("id", id);
                _DbConnection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = Mapper(reader);
                    }
                };
                _DbConnection.Close();
            };
            return result;
        }

        public Artist Create(Artist artist)
        {
            Artist result;
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "INSERT INTO [Artist] ([NAME],[BIRTH_DATE],[DEATH_DATE]) " +
                                      " OUTPUT INSERTED.* " +
                                      "VALUES (@name,@birthdate,@deathdate)";
                command.addParamWithValue("name", artist.Name);
                command.addParamWithValue("birthdate", artist.Birthdate);
                command.addParamWithValue("deathdate", artist.Deathdate);
                _DbConnection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    // TODO : Ca aurait été bien de gérer l'erreur de nom déjà pris vu que vous avez mis une contrainte unique dessus
                    if (!reader.Read())
                    {
                        throw new Exception("Erreur lors de l'ajout de l'artiste");
                    }
                    result = Mapper(reader);
                };
                _DbConnection.Close();
            };
            return result;
        }

        public bool Update(int id, Artist artist)
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText =
                    "UPDATE [Artist]" +
                    " SET [NAME] = @name," +
                    "     [BIRTH_DATE] = @birthdate," +
                    "     [DEATH_DATE] = @deathdate" +
                    " WHERE [Id_ARTIST] = @id";
                command.addParamWithValue("name", artist.Name);
                command.addParamWithValue("birthdate", artist.Birthdate);
                command.addParamWithValue("deathdate", artist.Deathdate);
                command.addParamWithValue("id", id);
                _DbConnection.Open();
                int nbRowUpdated = command.ExecuteNonQuery();
                _DbConnection.Close();
                return nbRowUpdated == 1;
            }
        }

        public bool Delete(int id)
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "DELETE FROM [Artist] WHERE [Id_ARTIST] = @id";
                command.addParamWithValue("id", id);
                _DbConnection.Open();
                int nbRowDeleted = command.ExecuteNonQuery();
                _DbConnection.Close();
                return nbRowDeleted == 1;
            };
        }

        public bool IsSingingOnTrack(int id)
        {
            bool isSinging = false;

            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Track_Artist] WHERE [ARTIST_ID] = @Id";
                command.addParamWithValue("Id", id);

                _DbConnection.Open();
                using ( DbDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read()) // Si j'arrive à lire au moins une ligne, c'est que notre artist est bien présent au moins une fois dans la M to M
                    {
                        isSinging = true;
                    }
                }

                _DbConnection.Close();

            }
            return isSinging;
        }
    }
}
