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
    public class QuesterRepository : BaseRepository, IQuesterRepository<Quester>
    {

        public QuesterRepository(IConfiguration config) : base(config)
        {
        }

        public bool? CheckQuester(Quester q)
        {
            string Query = "SELECT Id FROM Questers WHERE Username = @username AND Password = @password";
            Command cmd = new Command(Query);
            cmd.AddParameter("username", q.Username);
            cmd.AddParameter("password", q.Password);

            int Id;

            try
            {
                Id = (int)_connection.ExecuteScalar(cmd);
            }
            catch (Exception e)
            {
                Id = 0;
                throw new Exception(e.Message);
            }

            if (Id > 0)
            {
                Command checkActive = new Command("SELECT Id FROM [Questers] WHERE Id = " + Id + " AND IsActive = 1");


                if ((int)_connection.ExecuteScalar(checkActive) > 0) return true;
                else return false;
            }
            else
            {
                return null;
            }

        }

        public Quester GetByUsername(string username)
        {
            Command cmd = new Command("SELECT * FROM [Questers] WHERE Username = @username");
            cmd.AddParameter("username", username);
            return _connection.ExecuteReader(cmd, Converter.ConvertQuester).First();
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE FROM [Questers] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Quester> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [Questers]");
            return _connection.ExecuteReader<Quester>(cmd, Converter.ConvertQuester);
        }

        public Quester GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Questers] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converter.ConvertQuester).First();
        }

        public void Insert(Quester q)
        {
            string query = "INSERT INTO [Questers] (Username, Email, Password, BirthDate) VALUES(@username, @email, @password, @birthDate)";
            Command cmd = new Command(query);
            cmd.AddParameter("username", q.Username);
            cmd.AddParameter("email", q.Email);
            cmd.AddParameter("password", q.Password);
            cmd.AddParameter("birthDate", q.BirthDate);

            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Quester q)
        {
            string query = "UPDATE [Questers] SET Username = @username, Email = @email, Password = @password, BirthDate = @birthDate" +
                " WHERE Id = @Id";
            Command cmd = new Command(query);
            cmd.AddParameter("username", q.Username);
            cmd.AddParameter("email", q.Email);
            cmd.AddParameter("password", q.Password);
            cmd.AddParameter("birthDate", q.BirthDate);
            cmd.AddParameter("Id", q.Id);

            _connection.ExecuteNonQuery(cmd);
        }

        public void SetAdmin(int Id)
        {
            string Query = "UPDATE [Questers] SET IsAdmin = @isAdmin WHERE Id = @id";
            Command cmd = new Command(Query);
            cmd.AddParameter("isAdmin", GetById(Id).IsAdmin ? 0 : 1);
            cmd.AddParameter("Id", Id);
            _connection.ExecuteNonQuery(cmd);
        }
    }
}
