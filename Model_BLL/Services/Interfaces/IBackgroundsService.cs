using Model_BLL.Models;

namespace Model_BLL.Services.Interfaces
{
    public interface IBackgroundsService
    {
        IEnumerable<Background> GetAllBackgrounds();
        Background GetById(int Id);
        void addBackground(Background b);
        void DeleteBackground(int Id);
        void UpdateBackground(Background b);
    }
}
