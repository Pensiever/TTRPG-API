using DAL.Interfaces;
using dal = DAL.Models;
using Model_BLL.Models;
using Model_BLL.Tools;
using Model_BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_BLL.Services
{
    public class GenresService : IGenresService
    {
        IGenresRepository<dal.Genre> _repo;
        public GenresService(IGenresRepository<dal.Genre> GenresRepo)
        {
            _repo = GenresRepo;
        }

        public IEnumerable<Genre> GetAll()
        {
            return _repo.GetAll().Select(x => x.toModel());
        }

        public Genre GetById(int Id)
        {
            return _repo.GetById(Id).toModel();
        }

        public void CreateGenre(Genre g)
        {
            _repo.Insert(g.toDal());
        }

        public void Update(Genre g)
        {
            _repo.Update(g.toDal());
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }
    }
}