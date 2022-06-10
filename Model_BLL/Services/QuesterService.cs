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
    public class QuesterService : IQuesterService
    {
        IQuesterRepository<dal.Quester> _repo;
        public QuesterService(IQuesterRepository<dal.Quester> QuesterRepo)
        {
            _repo = QuesterRepo;
        }

        public IEnumerable<Quester> GetAll()
        {
            return _repo.GetAll().Select(x => x.toModel());
        }

        public bool? CheckQuester(Quester q)
        {
            bool? reponse = _repo.CheckQuester(q.toDal());
            return reponse;
        }

        public Quester GetById(int Id)
        {
            return _repo.GetById(Id).toModel();
        }

        public Quester GetByUsername(string Username)
        {
            return _repo.GetByUsername(Username).toModel();
        }

        public void Register(Quester quester)
        {
            _repo.Insert(quester.toDal());
        }

        public void Switchactivate(int Id)
        {
            _repo.Delete(Id);
        }

        public void Update(Quester q)
        {
            _repo.Update(q.toDal());
        }

        public void SwitchAdmin(int Id)
        {
            _repo.SetAdmin(Id);
        }
    }
}
