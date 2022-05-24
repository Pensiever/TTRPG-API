using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IQuesterRepository<Quester>
    {
        IEnumerable<Quester> GetAll();
        Quester GetById(int id);
        void Insert(Quester q);
        void Update(Quester q);
        bool Delete(int Id);
        bool? CheckQuester(Quester q);
        Quester GetByUsername(string username);
        void SetAdmin(int Id);
    }
}
