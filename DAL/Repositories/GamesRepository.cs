using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoToolbox;
using DAL.Interfaces;
using DAL.Models;
using DAL.Tools;
using Microsoft.Extensions.Configuration;

namespace DAL.Repositories
{
    public class GamesRepository : BaseRepository, IGamesRepository<Game>
    {

        public GamesRepository(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE FROM [Games] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Game> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [Games]");
            return _connection.ExecuteReader<Game>(cmd, Converter.ConvertGame);
        }

        public Game GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Games] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converter.ConvertGame).First();
        }

        public void Insert(Game g)
        {
            string query = "INSERT INTO [Games] (Name, Description, Image) VALUES(@name, @description, @image)";
            Command cmd = new Command(query);
            cmd.AddParameter("name", g.Name);
            cmd.AddParameter("description", g.Description);
            cmd.AddParameter("image", g.Image);

            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Game g)
        {
            string query = "UPDATE [Games] SET Name = @name, Description = @description, Image = @image" +
                " WHERE Id = @Id";
            Command cmd = new Command(query);
            cmd.AddParameter("name", g.Name);
            cmd.AddParameter("description", g.Description);
            cmd.AddParameter("image", g.Image);
            cmd.AddParameter("Id", g.Id);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}