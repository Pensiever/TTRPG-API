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
    public class BackgroundsService
    {
        IBackgroundsRepository<dal.Background> _repo;
        public BackgroundsService(IBackgroundsRepository<dal.Background> BackgroundsRepo)
        {
            _repo = BackgroundsRepo;
        }

        public Background GetById(int Id)
        {
            return _repo.GetById(Id).toModel();
        }

        public IEnumerable<Background> GetAllBackgrounds()
        {
            return _repo.GetAllBackgrounds().Select(x => x.toModel());
        }

        public void addBackground(Background b)
        {
            _repo.InsertBackground(b.toDal());
        }

        public void DeleteBackground(int Id)
        {
            _repo.DeleteBackground(Id);
        }

        public void UpdateBackground(Background b)
        {
            _repo.UpdateBackground(b.toDal());
        }
    }
}
