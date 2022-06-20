using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBackgroundsRepository<Background>
    {
        IEnumerable<Background> GetAllBackgrounds();
        Background GetById(int Id);
        void InsertBackground(Background b);
        bool DeleteBackground(int Id);
        void UpdateBackground(Background b);
    }
}
