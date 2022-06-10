using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenresRepository<Genre>
    {
        IEnumerable<Genre> GetAll();
        Genre GetById(int id);
        void Insert(Genre g);
        void Update(Genre g);
        bool Delete(int Id);
    }
}
