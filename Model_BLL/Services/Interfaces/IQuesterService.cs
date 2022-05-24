using Model_BLL.Models;

namespace Model_BLL.Services.Interfaces
{
    public interface IQuesterService
    {
        bool? CheckQuester(Quester q);
        IEnumerable<Quester> GetAll();
        Quester GetByUsername(string Username);
        Quester GetById(int Id);
        void Register(Quester quester);
        void Switchactivate(int Id);
        void Update(Quester q);
        void SwitchAdmin(int Id);
    }
}
