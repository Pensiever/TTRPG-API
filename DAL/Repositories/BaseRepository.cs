using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOToolbox;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL.Repositories
{
    public class BaseRepository
    {
        internal Connection _connection;

        IConfiguration _config;

        public SqlConnection Connection()
        {
            return new SqlConnection(_config.GetConnectionString("default"));
        }

        public BaseRepository(IConfiguration config)
        {
            _config = config;
            _connection = new Connection(config.GetConnectionString("default"));
        }
    }
}
