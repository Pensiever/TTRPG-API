using Model_BLL.Models;

namespace Model_BLL.Services.Interfaces
{
    public interface IGenresService
    {
        IEnumerable<Genre> GetAll();
        Genre GetById(int id);
        void CreateGenre(Genre g);
        void Update(Genre g);
        void Delete(int Id);
    }
}
