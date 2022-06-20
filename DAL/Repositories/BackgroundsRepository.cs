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
    public class BackgroundsRepository : BaseRepository, IBackgroundsRepository<Background>
    {
        public BackgroundsRepository(IConfiguration config) : base(config)
        {
        }

        public bool DeleteBackground(int Id)
        {
            Command cmd = new Command("DELETE FROM Backgrounds] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public Background GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Questers] WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, Converter.ConvertBackground).First();
        }

        public IEnumerable<Background> GetAllBackgrounds()
        {
            Command cmd = new Command("SELECT * FROM [Backgrounds]");
            return _connection.ExecuteReader<Background>(cmd, Converter.ConvertBackground);
        }

        public void InsertBackground(Background b)
        {
            string query = "INSERT INTO [Backgounds] (Name, Image, NavTop, NavTopFont, NavSide, NavSideFont, NavSideButton, Footer, FooterFont) VALUES(@name, @image, @navTop, @navTopFont, @navSide, @navSideFont, @navSideButton, @footer, @footerFont)";
            Command cmd = new Command(query);
            cmd.AddParameter("name", b.Name);
            cmd.AddParameter("image", b.Image);
            cmd.AddParameter("navTop", b.NavTop);
            cmd.AddParameter("navTopFont", b.NavTopFont);
            cmd.AddParameter("navSide", b.NavSide);
            cmd.AddParameter("navSideFont", b.NavSideFont);
            cmd.AddParameter("navSideButton", b.NavSideButton);
            cmd.AddParameter("footer", b.Footer);
            cmd.AddParameter("footerFont", b.FooterFont);

            _connection.ExecuteNonQuery(cmd);
        }

        public void UpdateBackground(Background b)
        {
            string query = "UPDATE [Backgounds] SET Name = @name, Image = @image, NavTop = @navTop, NavTopFont = @navTopFont, NavSide = navSide, NavSideFont = navSideFont, NavSideButton = navSideButton, Footer = footer, FooterFont = footerFont" +
                " WHERE Id = @Id";
            Command cmd = new Command(query);
            cmd.AddParameter("Id", b.Id);
            cmd.AddParameter("name", b.Name);
            cmd.AddParameter("image", b.Image);
            cmd.AddParameter("navTop", b.NavTop);
            cmd.AddParameter("navTopFont", b.NavTopFont);
            cmd.AddParameter("navSide", b.NavSide);
            cmd.AddParameter("navSideFont", b.NavSideFont);
            cmd.AddParameter("navSideButton", b.NavSideButton);
            cmd.AddParameter("footer", b.Footer);
            cmd.AddParameter("footerFont", b.FooterFont);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
