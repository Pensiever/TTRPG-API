using Model_BLL.Models;

namespace Model_BLL.Services.Interfaces
{
    public interface IGamesService
    {
        IEnumerable<Game> GetAll();
        Game GetById(int id);
        void CreateGame(Game g);
        void Update(Game g);
        void Delete(int Id);
    }
}
