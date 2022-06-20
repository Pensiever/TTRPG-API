using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOToolbox;
using DAL.Interfaces;
using DAL.Models;
using DAL.Tools;
using Microsoft.Extensions.Configuration;

namespace DAL.Repositories
{
    public class GenresRepository : BaseRepository, IGenresRepository<Genre>
    {

        public GenresRepository(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE FROM [Genres] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Genre> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [Genres]");
            return _connection.ExecuteReader<Genre>(cmd, Converter.ConvertGenre);
        }

        public Genre GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Genres] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converter.ConvertGenre).First();
        }

        public void Insert(Genre g)
        {
            string query = "INSERT INTO [Genres] (Name, Description, Image) VALUES(@name, @description, @image)";
            Command cmd = new Command(query);
            cmd.AddParameter("name", g.Name);
            cmd.AddParameter("description", g.Description);
            cmd.AddParameter("image", g.Image);

            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Genre g)
        {
            string query = "UPDATE [Genres] SET Name = @name, Description = @description, Image = @image" +
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