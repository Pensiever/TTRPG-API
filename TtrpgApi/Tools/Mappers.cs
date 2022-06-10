using TtrpgApi.Models;
using Model_BLL.Models;

namespace TtrpgApi.Tools
{
    public static class Mappers
    {
        public static Quester toModel(this NewQuesterInfo newQuester)
        {
            return new Quester
            {
                Username = newQuester.Username,
                Email = newQuester.Email,
                Password = newQuester.Password,
                BirthDate = newQuester.BirthDate
            };
        }

        public static Quester toModel(this ConnectedQuester connectedQuester)
        {
            return new Quester
            {
                Id = connectedQuester.Id,
                Username = connectedQuester.Username,
                Email = connectedQuester.Email,
                BirthDate = connectedQuester.BirthDate,
                IsActive = connectedQuester.IsActive,
                IsAdmin = connectedQuester.IsAdmin,
                IsBanned = connectedQuester.IsBanned,
                Strikes = connectedQuester.Strikes,
                BackgroundId = connectedQuester.BackgroundId,
                OnlinePlay = connectedQuester.OnlinePlay,
                OfflinePlay = connectedQuester.OfflinePlay,
            };
        }
    }
}
