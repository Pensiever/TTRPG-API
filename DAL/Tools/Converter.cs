using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using System.Data.SqlClient;

namespace DAL.Tools
{
    public static class Converter
    {
        public static Quester ConvertQuester(SqlDataReader reader)
        {
            return new Quester
            {
                Id = (int)reader["Id"],
                Username = reader["Username"].ToString(),
                Email = reader["Email"].ToString(),
                Password = reader["Password"].ToString(),
                BirthDate = (DateTime)reader["BirthDate"],
                IsActive = (bool)reader["IsActive"],
                IsAdmin = (bool)reader["IsAdmin"],
                IsBanned = (bool)reader["IsBanned"],
                Strikes = (int)reader["Strikes"],
                BackgroundId = (int)reader["BackgroundId"],
                Bio = reader["Bio"].ToString(),
                OnlinePlay = (bool)reader["OnlinePlay"],
                OfflinePlay = (bool)reader["OfflinePlay"],
                PostalCode = reader["PostalCode"] == DBNull.Value ? null : (int)reader["PostalCode"]
            };
        }

        public static Game ConvertGame(SqlDataReader reader)
        {
            return new Game
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Image = reader["Image"].ToString()
            };
        }

        public static Genre ConvertGenre(SqlDataReader reader)
        {
            return new Genre
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Image = reader["Image"].ToString()
            };
        }

        public static Favorite ConvertFavorite(SqlDataReader reader)
        {
            return new Favorite
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Image = reader["Image"].ToString()
            };
        }
    }
}
