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

        public static Game toModel(this NewGameInfo newGame)
        {
            return new Game
            {
                Name = newGame.Name,
                Description = newGame.Description,
                Image = newGame.Image,
            };
        }

        public static Genre toModel(this NewGenreInfo newGenre)
        {
            return new Genre
            {
                Name = newGenre.Name,
                Description = newGenre.Description,
                Image = newGenre.Image,
            };
        }

        public static Background toModel(this NewBackground newBackground)
        {
            return new Background
            {
                Name = newBackground.Name,
                Image = newBackground.Image,
                NavTop = newBackground.NavTop,
                NavTopFont = newBackground.NavTopFont,
                NavSide = newBackground.NavSide,
                NavSideFont = newBackground.NavSideFont,
                NavSideButton = newBackground.NavSideButton,
                Footer = newBackground.Footer,
                FooterFont = newBackground.FooterFont
            };
        }
    }
}
