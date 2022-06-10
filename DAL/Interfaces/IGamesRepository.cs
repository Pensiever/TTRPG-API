using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGamesRepository<Game>
    {
        IEnumerable<Game> GetAll();
        Game GetById(int id);
        void Insert(Game g);
        void Update(Game g);
        bool Delete(int Id);
    }
}
