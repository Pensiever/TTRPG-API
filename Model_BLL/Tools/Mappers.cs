using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = Model_BLL.Models;
using dal = DAL.Models;
using DAL.Interfaces;

namespace Model_BLL.Tools
{
    public static class Mappers
    {
        public static model.Quester toModel(this dal.Quester q)
        {
            return new model.Quester
            {
                Id = q.Id,
                Username = q.Username,
                Email = q.Email,
                Password = q.Password,
                BirthDate = q.BirthDate,
                IsActive = q.IsActive,
                IsAdmin = q.IsAdmin,
                IsBanned = q.IsBanned,
                Strikes = q.Strikes,
                BackgroundId = q.BackgroundId,
                Bio = q.Bio,
                OnlinePlay = q.OnlinePlay,
                OfflinePlay = q.OfflinePlay,
                PostalCode = q.PostalCode
            };
        }

        public static model.Game toModel(this dal.Game g)
        {
            return new model.Game
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                Image = g.Image
            };
        }

        public static model.Genre toModel(this dal.Genre g)
        {
            return new model.Genre
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                Image = g.Image
            };
        }

        public static model.Favorite toModel(this dal.Favorite f)
        {
            return new model.Favorite
            {
                Id = f.Id,
                QuesterId = f.QuesterId,
                GameGenreId = f.GameGenreId
            };
        }

        public static dal.Quester toDal(this model.Quester q)
        {
            return new dal.Quester
            {
                Id = q.Id,
                Username = q.Username,
                Email = q.Email,
                Password = q.Password,
                BirthDate = q.BirthDate,
                IsActive = q.IsActive,
                IsAdmin = q.IsAdmin,
                IsBanned = q.IsBanned,
                Strikes = q.Strikes,
                BackgroundId = q.BackgroundId,
                Bio = q.Bio,
                OnlinePlay = q.OnlinePlay,
                OfflinePlay = q.OfflinePlay,
                PostalCode = q.PostalCode
            };
        }

        public static dal.Game toDal(this model.Game g)
        {
            return new dal.Game
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                Image = g.Image
            };
        }

        public static dal.Genre toDal(this model.Genre g)
        {
            return new dal.Genre
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                Image = g.Image
            };
        }

        public static dal.Favorite toDal(this model.Favorite f)
        {
            return new dal.Favorite
            {
                Id = f.Id,
                QuesterId = f.QuesterId,
                GameGenreId = f.GameGenreId
            };
        }

        public static dal.Background toDal(this model.Background b)
        {
            return new dal.Background
            {
                Id = b.Id,
                Name = b.Name,
                Image = b.Image,
                NavTop = b.NavTop,
                NavTopFont = b.NavTopFont,
                NavSide = b.NavSide,
                NavSideFont = b.NavSideFont,
                NavSideButton = b.NavSideButton,
                Footer = b.Footer,
                FooterFont = b.FooterFont
            };
        }

        public static model.Background toModel(this dal.Background b)
        {
            return new model.Background
            {
                Id = b.Id,
                Name = b.Name,
                Image = b.Image,
                NavTop = b.NavTop,
                NavTopFont = b.NavTopFont,
                NavSide = b.NavSide,
                NavSideFont = b.NavSideFont,
                NavSideButton = b.NavSideButton,
                Footer = b.Footer,
                FooterFont = b.FooterFont
            };
        }
    }
}
