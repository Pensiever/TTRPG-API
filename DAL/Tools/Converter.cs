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
        public static Quester Convert(SqlDataReader reader)
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
                PostalCode = (int)reader["PostalCode"]
            };
        }
    }
}
